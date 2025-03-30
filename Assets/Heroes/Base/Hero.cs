using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Hero : MonoBehaviour,  HeroIsMoveable, IsSelectable
{
    public Rigidbody2D RB { get ; set; }
    public bool IsFacingRight { get; set; }
    public bool IsFacingUp { get; set; }
    public float DefaultVelocity { get; set; }
    
    protected float distanceToChangeGoal { get; set; }



    private NavMeshAgent agent { get; set; }
    private Transform heroPosition { get; set; }

    // drag n drop example:
    private Vector3 offset;
    private GameObject ghostObject;
    [SerializeField] private GameObject waypointPrefub;
    //

    private string path = "Avatars/";
    [SerializeField] private string spriteName = "1";


    #region Test
    //StateMaschine block
    public HeroStateMaschine StateMaschine { get; set; }
    public HeroStateIdle IdleState { get; set; }
    //
    #endregion

    public event Action<Hero> HeroSelected;

    private Hero()
    {


    }

    private void Awake()
    {
        StateMaschine = new HeroStateMaschine();
        IdleState = new HeroStateIdle(this, StateMaschine);

       // ExporeRuneState = new HeroEploreRunesState(this, StateMaschine);
        StateMaschine.Initialize(IdleState);
        //StateMaschine.Initialize(ExporeRuneState);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


        //Vector2 point = new Vector3(100, 100);

        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
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

    public void Movehero(Vector2 velocity)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //float temp = agent.velocity;
        //Debug.Log();
        StateMaschine.CurrentHeroState.FrameUpdate();
    }

    //public void ChangeActualVelocity (float newVelocity)   { ActualVelocity = newVelocity; }
    public bool GetIsFacingRight () { return IsFacingRight; }
    public void SetIsFacingRight(bool newBool) {IsFacingRight = newBool; }
    public bool GetIsFacingUp() { return IsFacingUp; }
    public void SetIsFacingUp(bool newBool) { IsFacingUp = newBool; }
    public string GetAvatarSprite() { return path + spriteName; }
    public Transform GetHeroPosition () { return heroPosition; }
    public NavMeshAgent GetAgent() { return agent; }
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
        // Destroy the ghost object when dragging is complete                
        this.gameObject.GetComponent<HeroStatController>().SetTargetWaypoint(ghostObject.transform.position);
        Destroy(ghostObject);
    }
    #endregion

    private void HeroIsSelected()
    {
        //GameObject testObject = this.gameObject;
        HeroSelected?.Invoke(this);
        this.GetComponent<HeroStatController>().DrawWaypoints();    
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepsSound
    }




}