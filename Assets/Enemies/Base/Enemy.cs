using System;
using System.IO;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent { get; set; }
    private Transform position { get; set; }
    private Attack attack;
    private EnemyAggressionHandler eAggressionHandler;
    private EStatHandler eStatHandler;

    #region StateMaschine
    //StateMaschine block
    public StateMaschine StateMaschine { get; set; }
    public EnemyStateIdle IdleState { get; set; }
    public EnemyStateMove MoveState { get; set; }
    public EnemyStateSearchTarget SerachTargetState { get; set; }
    public EnemyStateCloseToHero CloseToHero { get; set; }
    public EnemyStateCharge ChargeState { get; set; }
    public EnemyStateAttackRegular RegularAttackState { get; set; }

    //private HeroStateRestoreEnergy RestoreEnergy { get; set; }
    #endregion

    #region MainStats
    private Skill strenght;
    private Skill dexterity;
    #endregion

    #region SecondarySkills
        private Skill chargeSkill;
        private Skill attackSkill;
    #endregion

                     private string path = "Avatars/bestiary/";
    [SerializeField] private string spriteName = "M1";
                     private string monsterName = "Sceleton";

    public event Action<Enemy> EnemySelected;

    public Skill Strenght { get => strenght; set => strenght = value; }
    public Skill Dexterity { get => dexterity; set => dexterity = value; }
    public Skill ChargeSkill { get => chargeSkill; set => chargeSkill = value; }
    public Skill AttackSkill { get => attackSkill; set => attackSkill = value; }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        eAggressionHandler = this.GetComponent<EnemyAggressionHandler>();
        eStatHandler = this.GetComponent<EStatHandler>();



        float randomStat = UnityEngine.Random.Range(0.5f, 3f);
        strenght = new Skill(randomStat);
        //randomStat = Random.Range(0.5f, 3f);
        chargeSkill = new Skill(UnityEngine.Random.Range(0.5f, 3f));
        attackSkill = new Skill(UnityEngine.Random.Range(0, 2f));

        attack = new Attack(this);


        StateMaschine      = new StateMaschine();
        IdleState          = new EnemyStateIdle (this, StateMaschine);
        MoveState          = new EnemyStateMove(this, StateMaschine);
        SerachTargetState  = new EnemyStateSearchTarget (this, StateMaschine);
        CloseToHero        = new EnemyStateCloseToHero (this, StateMaschine);
        ChargeState        = new EnemyStateCharge (this, StateMaschine);
        RegularAttackState = new EnemyStateAttackRegular(this, StateMaschine);

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

    public Attack GetAttack() {  return attack; }
    public EnemyAggressionHandler GetEAggressionHandler() { return eAggressionHandler; }
    public EStatHandler GetEStatHandler() { return eStatHandler; }  

    private void OnMouseDown()
    {
        RaidGlobals.SetSelectedObject(this.gameObject);
        //this.GetHeroStats().DrawWaypoints();
        EnemySelected?.Invoke(this);
    }

    public string GetAvatarSprite() { return path + spriteName; }
    public string GetMonsterName() { return monsterName; }


}
