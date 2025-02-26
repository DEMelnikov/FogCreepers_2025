using NUnit.Framework.Constraints;
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
    public bool IsFacingUp { get; set; }
    public float DefaultVelocity { get; set; }
    
    protected float distanceToChangeGoal { get; set; }
    //public float ActualVelocity { get; set; }

    public HeroStateMaschine StateMaschine { get; set; }
    public HeroStateIdle IdleState { get; set; }
    public HeroEploreRunesState ExporeRuneState { get; set; }
    private NavMeshAgent agent { get; set; }
    private Transform heroPosition { get; set; }
    private int RadiusRandomSearch { get; set; }
    private bool RuneKnown { get; set; }
    private GameObject KnownRune { get; set; }


    #region Test

    #endregion

    private Hero()
    {


    }
    private void Awake()
    {
        StateMaschine = new HeroStateMaschine();
        IdleState = new HeroStateIdle(this, StateMaschine);
        ExporeRuneState = new HeroEploreRunesState(this, StateMaschine);
        //StateMaschine.Initialize(IdleState);
        StateMaschine.Initialize(ExporeRuneState);


        RadiusRandomSearch = 50;
        distanceToChangeGoal = 5;
        RuneKnown = false;


        Vector2 point = new Vector3(100, 100);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = point;
        heroPosition = GetComponent<Transform>();

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
    public Transform GetHeroPosition () { return heroPosition; }
    public int GetRadiusRandomSearch() { return RadiusRandomSearch; }
    public float GetdistanceToChangeGoal() { return distanceToChangeGoal; }
    public NavMeshAgent GetAgent() { return agent; }
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