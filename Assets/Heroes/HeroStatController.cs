using NUnit.Framework.Constraints;
using UnityEngine;

public class HeroStatController : MonoBehaviour
{
    [SerializeField] private string HeroName;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float maxEnergy = 100;
    [SerializeField] private float maxWill   = 100;


    #region MovementStats
    [SerializeField] private bool HaveWayPoint = false;
    [SerializeField] private Vector2 TargetWaypoint = new Vector2();
    [SerializeField] private float NewWaypointRadius = 2f;
    [SerializeField] private GameObject WayPointPrefub;
    [SerializeField] private bool MoveAllowed = true;
    [SerializeField] private float BaseSpeed = 2f;
    [SerializeField] private float SpeedEP = 0.01f;
                     //private RStatClass MoveSettings = new RStatClass(0, 6,2); //TODO - убрать константы в конструктор
                     //private RStatClass MoveEP = new RStatClass(-0.005f, +0.03f, 0.01f);
                     private ActionSettingsAndEP moveSettings;
    #endregion

    [SerializeField] private float RestoreEnergyEP = 0.015f;
    [SerializeField] private float TargetEnergyToRestore = 0.25f;
    [SerializeField] private float CriticalLevelEnergy = 0.1f;
    

    public StatClass Health;
    public StatClass Energy;
    public StatClass Will;

    #region MainStats
    private Skill strenght;
    private Skill dexterity;
    #endregion

    #region SecondarySkills
    private Skill chargeSkill;
    private Skill attackSkill;
    #endregion



    private void Awake()
    {

        RStatClass MoveParams = new RStatClass(0, 6, 2);                 //TODO - убрать константы в конструктор
        RStatClass MovePrice  = new RStatClass(-0.005f, +0.03f, 0.01f);  //TODO - убрать константы в конструктор

        moveSettings = new ActionSettingsAndEP(MoveParams, MovePrice);

        strenght    = new Skill(1);
        dexterity   = new Skill(1);
        chargeSkill = new Skill(1); 
        attackSkill = new Skill(1);

        //TargetEnergyToRestore = 0.25f;

    }
    private HeroStatController ()
    {
      //  int randomInt = Random.Range(0, (int)maxHealth);
        Health = new StatClass(0, maxHealth, 50, maxHealth);
        Energy = new StatClass(0,maxEnergy, 35, maxEnergy);
        Will   = new StatClass(0,maxWill, 25, maxWill);

    }
    public ActionSettingsAndEP MoveSettings { get => moveSettings; set => moveSettings = value; }

    public string GetHeroName()  {return HeroName;}
    public bool GetMoveAllowed() { return MoveAllowed;}
    public void SetMoveAllowed(bool newValue) {  MoveAllowed = newValue;}
    public float GetBaseSpeed() { return BaseSpeed;}
    public float GetSpeedEP() {  return SpeedEP;}
    public float GetRestoreEnergyEP() { return RestoreEnergyEP;}
    public Vector2 GetTargetWaypoint()  { return TargetWaypoint;}
    public void SetTargetWaypoint(Vector2 newWaypoint) 
    {
        if (Vector3.Distance(newWaypoint, this.gameObject.transform.position) >= NewWaypointRadius)
        {
            TargetWaypoint = newWaypoint;
            Debug.Log("New Waypoint");
            HaveWayPoint = true;
            if (this.gameObject.GetComponent<Hero>().StateMaschine.CurrentHeroState.GetStateName() == "Move")
            {
                Debug.Log("reset destination");
                this.gameObject.GetComponent<Hero>().StateMaschine.CurrentHeroState.EnterState();
            }
            DrawWaypoints();
        }
    }
    public void WaypointReached()
    {
        HaveWayPoint = false;
        TargetWaypoint = new Vector2 (0, 0);
        DrawWaypoints();
    }
    public StatClass GetHealth() {  return Health; }
    public StatClass GetEnergy() { return Energy; }
    public float GetTargetEnergyToRestore() { return TargetEnergyToRestore; }
    public void SetTargetEnergyToRestore(float value ) { TargetEnergyToRestore = value; }
    public float GetCriticalLevelEnergy() { return CriticalLevelEnergy; }
    public void SetCriticalLevelEnergy(float value) {  CriticalLevelEnergy = value; }
    public void ChangeEnergy(float changeValue) {Energy.ChangeActual(changeValue);}
    public StatClass GetWill() { return Will; }
    public bool GetHaveWaypoint() { return HaveWayPoint; }

    public Skill GetStrenght()     { return strenght; }
    public Skill GetDexterity()    { return dexterity; }
    public Skill GetAttackSkill()  { return attackSkill; }
    public Skill GetChargeSkill() { return chargeSkill; }

    //public RStatClass GetMoveSettings() {  return MoveSettings; }
    //public void SetMoveSettings(float min, float max, float actual, float def)
    //{
    //    this.MoveSettings.SetMax(max);
    //    this.MoveSettings.SetMin(min);
    //    this.MoveSettings.SetActual(actual);
    //    this.MoveSettings.SetDef(def);
    //}

    //public void SetMoveSettingsActual(float value)
    //{
    //    MoveSettings.SetActual(value);
    //}
    //public RStatClass GetMoveEP() { return MoveEP; }
    //public void SetMoveEP(float min, float max, float actual, float def)
    //{
    //    MoveEP.SetMin(min);
    //    MoveEP.SetMax(max);
    //    MoveEP.SetActual(actual);
    //    MoveEP.SetDef(def);
    //}


    public void DrawWaypoints()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Waypoint");

        foreach (GameObject point in gameObjects)
        {
           if (point != null) { Destroy(point); }
        }

        if (HaveWayPoint)
        {
            Instantiate(WayPointPrefub, TargetWaypoint, Quaternion.identity);
        }


    }

    //public StatClass SetActual


}
