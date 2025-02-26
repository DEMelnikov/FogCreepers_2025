using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hero : MonoBehaviour, HeroISDamageable, HeroIsMoveable
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get ; set; }
    public bool IsFacingRight { get; set; }
    public float DefaultVelocity { get; set; }
    public float ActualVelocity { get; set; }

    public HeroStateMaschine StateMaschine { get; set; }
    public HeroStateIdle IdleState { get; set; }

    #region Test

    #endregion

    private Hero()
    {
        StateMaschine = new HeroStateMaschine();
        IdleState = new HeroStateIdle(this, StateMaschine);
        StateMaschine.CurrentHeroState = IdleState;
    }
    private void Awake()
    {

        Vector2 point = new Vector3(100, 100);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = point;

        //this.GetComponent<NavMeshAgent>().nextPosition(new Vector3(100, 100, 0));
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMaschine.CurrentHeroState.FrameUpdate();
    }

    public void ChangeActualVelocity (float newVelocity)   { ActualVelocity = newVelocity; }
    private void FixedUpdate()
    {
        StateMaschine.CurrentHeroState.PhysicUpdate();
    }
    private void AnimationTriggerEvent (AnimationTriggerType triggerType) { }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepsSound
    }
}