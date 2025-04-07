using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent { get; set; }
    private Transform position { get; set; }

    #region StateMaschine
    //StateMaschine block
    public StateMaschine StateMaschine { get; set; }
    public EnemyStateIdle IdleState { get; set; }
    public EnemyStateMove MoveState { get; set; }
    public EnemyStateSearchTarget SerachTargetState { get; set; }
    public EnemyStateCloseToHero CloseToHero { get; set; }
    public EnemyStateCharge ChargeState { get; set; }
    //private HeroStateRestoreEnergy RestoreEnergy { get; set; }

    //
    #endregion

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StateMaschine = new StateMaschine();
        IdleState = new EnemyStateIdle (this, StateMaschine);
        MoveState = new EnemyStateMove(this, StateMaschine);
        SerachTargetState = new EnemyStateSearchTarget (this, StateMaschine);
        CloseToHero = new EnemyStateCloseToHero (this, StateMaschine);
        ChargeState = new EnemyStateCharge (this, StateMaschine);

        StateMaschine.Initialize(IdleState);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMaschine.CurrentState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMaschine.CurrentState.PhysicUpdate();
    }
}
