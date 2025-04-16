using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;
using static UnityEditorInternal.ReorderableList;
using static UnityEngine.UI.Image;

public class Hero : MonoBehaviour,  HeroIsMoveable, IsSelectable
{
    public Rigidbody2D RB { get ; set; }
    private Camera cam;
    public bool IsFacingRight { get; set; }
    public bool IsFacingUp { get; set; }
    private HeroStatController statsH { get; set; }
    private hAgressionController agressionController;
    //public float DefaultVelocity { get; set; }    
    //protected float distanceToChangeGoal { get; set; }
    //public float DefaultVelocity { get; set; }    
    //protected float distanceToChangeGoal { get; set; }

    private NavMeshAgent agent { get; set; }
    private Transform heroPosition { get; set; }

    // drag n drop example:
    private Vector3 offset;
    private GameObject ghostObject;
    [SerializeField] private GameObject waypointPrefub;
    //

    private string path = "Avatars/";
    [SerializeField] private string spriteName = "1";


    #region StateMaschine
    //StateMaschine block
    public HeroStateMaschine StateMaschine { get; set; }
    public HeroStateIdle IdleState { get; set; }
    public HStateAttack AttackState { get; set; }
    public HeroStateMoving MoveState { get; set; }
    public HeroStateRestoreEnergy RestoreEnergy { get; set; }
    public HStateCharge ChargeState { get; set; }

    #endregion

    #region Skills
        private Skill defaultDefence;
    #endregion

    private Defence defence;

    public event Action<Hero> HeroSelected;


    public Skill DefaultDefence { get => defaultDefence; set => defaultDefence = value; }

    private void Awake()
    {
        StateMaschine  = new HeroStateMaschine();
        IdleState      = new HeroStateIdle(this, StateMaschine);
        MoveState      = new HeroStateMoving(this, StateMaschine);
        RestoreEnergy  = new HeroStateRestoreEnergy(this, StateMaschine);
        AttackState    = new HStateAttack(this, StateMaschine);
        ChargeState    = new HStateCharge(this, StateMaschine);

        statsH              = this.GetComponent<HeroStatController>();
        agressionController = this.GetComponent<hAgressionController>();    

        defence = new Defence(this);
        defaultDefence = new Skill(10); //

        StateMaschine.Initialize(IdleState);
        //StateMaschine.Initialize(ExporeRuneState);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        RB = gameObject.GetComponent<Rigidbody2D>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        //Vector2 point = new Vector3(100, 100);

       // agent.destination = point;
      //  heroPosition = GetComponent<Transform>();

        //this.GetComponent<NavMeshAgent>().nextPosition(new Vector3(100, 100, 0));
    }

    private void OnEnable()
    {
       // GameObject.Find("RuneListener (1)").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path + "1");
    }
    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Movehero(Vector2 velocity) //toDelete
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
         //cam = GetComponent<Camera>();
    }

    void Update()
    {
        //float temp = agent.velocity;
        //Debug.Log();
        StateMaschine.CurrentHeroState.FrameUpdate();
    }

    //public void ChangeActualVelocity (float newVelocity)   { ActualVelocity = newVelocity; }
    public HeroStatController GetHeroStats() { return statsH; }
    public bool GetIsFacingRight () { return IsFacingRight; }
    public void SetIsFacingRight(bool newBool) {IsFacingRight = newBool; }
    public bool GetIsFacingUp() { return IsFacingUp; }
    public void SetIsFacingUp(bool newBool) { IsFacingUp = newBool; }
    public string GetAvatarSprite() { return path + spriteName; }
    public Transform GetHeroPosition () { return heroPosition; }
    public NavMeshAgent GetAgent() { return agent; }
    public HeroStateMoving GetStateMoving() { return MoveState; }
    public HeroStateIdle GetStateIdle() { return IdleState; }
    public HeroStateRestoreEnergy GetStateRestoreEnergy() { return RestoreEnergy; }
    public hAgressionController GetAgressionController() { return agressionController; }

    private void FixedUpdate()
    {
        StateMaschine.CurrentHeroState.PhysicUpdate();
    }
    private void AnimationTriggerEvent (AnimationTriggerType triggerType) { }

    #region OnMouseEvents
    public void OnMouseDown()
    {
        // Debug.Log("U are 1/2 the champion!");
        HeroIsSelected();

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Create a ghost preview
        ghostObject = Instantiate(waypointPrefub, transform.position, Quaternion.identity);
        //ghostObject.GetComponent<Collider>().enabled = false;   
        ghostObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    }
    public void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        ghostObject.transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);



    }
    void OnMouseUp()
    {

        //if (ghostObject != null)
        //{
        //    Debug.Log("ghost not null " + ghostObject.transform.position.x.ToString());
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ghostObject.transform.position);    //Input.mousePosition);
        //    RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction);

        //    if (hit.Length>0)
        //    {
        //        Debug.Log("GGGGGGHit ");// + hit.collider.gameObject.name);
        //    }
        //}
        if (ghostObject != null)
        {
            //Debug.Log("ghost not null " + ghostObject.transform.position.x.ToString());
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ghostObject.transform.position);    //Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);

            //Debug.DrawRay(new Vector2(0,0), ghostObject.transform.position);

            ////Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.tag == "Monster")
                    {
                        Debug.Log("Monster in target" + hit.collider.tag);
                        if (this.agressionController.TargetEnemy != null)
                        {
                            this.agressionController.TargetEnemy.GetComponent<Enemy>().DisableIcon();
                        }
                        this.agressionController.TargetEnemy = hit.collider.gameObject;
                        this.agressionController.TargetEnemy.GetComponent<Enemy>().EnableIcon();
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else 
            {
                this.gameObject.GetComponent<HeroStatController>().SetTargetWaypoint(ghostObject.transform.position);
            }

        }
            // Destroy the ghost object when dragging is complete                

        Destroy(ghostObject);
    }
    #endregion

    private void HeroIsSelected()
    {
        //GameObject testObject = this.gameObject;
        RaidGlobals.SetSelectedObject(this.gameObject);
        this.GetHeroStats().DrawWaypoints();
        HeroSelected?.Invoke(this);
    }

    public Defence GetDefence() {  return defence; }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepsSound
    }

    public void tempTest()
    {
        Rigidbody2D _rb = gameObject.GetComponent<Rigidbody2D>();
        if (this.GetAgressionController().TargetEnemy != null) 
        {
            Vector2 qqq = (this.GetAgressionController().TargetEnemy.transform.position-this.transform.position).normalized;
            _rb.AddForce(qqq, ForceMode2D.Impulse);
            //_rb.angularVelocity = new Vector3(0, 0, 0);//this.GetAgressionController().TargetEnemy.transform.position;
            //_rb.MovePosition(this.GetAgressionController().TargetEnemy.transform.position * 0.6f);
        }

    }
}