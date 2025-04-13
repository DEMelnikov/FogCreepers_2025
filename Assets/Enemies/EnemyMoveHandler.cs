using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveHandler : MonoBehaviour
{
    #region MovementStats
    [SerializeField] private bool HaveWayPoint = false;
    [SerializeField] private Vector2 TargetWaypoint = new Vector2();
    //[SerializeField] private float NewWaypointRadius = 2f;
    //[SerializeField] private GameObject WayPointPrefub;
    [SerializeField] private bool MoveAllowed = true;
    //[SerializeField] private float BaseSpeed = 2f;
    [SerializeField] private float SpeedEP = 0.01f;
    
    [SerializeField] private float spreadToSetTargetPoint = 15;
    [SerializeField] private float objectCloseRange = 2f;
    [SerializeField] private float heroCloseRange = 10f;

    private ActionSettingsAndEP MoveSettings;

    private NavMeshAgent agent { get; set; }

    #endregion

    public float HeroCloseRange { get => heroCloseRange; set => heroCloseRange = value; }
    public float ObjectCloseRange { get => objectCloseRange; set => objectCloseRange = value; }

    public bool GetHaveWayPoint() { return HaveWayPoint; }
    public void SetHaveWaypoint(bool value) { HaveWayPoint = value; }
    public Vector2 GetTargetWaypoint() { return TargetWaypoint; }
    public void SetTargetWaypoint(Vector2 newWaypoint)
    {
        TargetWaypoint = newWaypoint;
        //Debug.Log("New Waypoint");
        HaveWayPoint = true;
        //agent.i
    }
    public bool GetMoveAllowed() {  return MoveAllowed; }
    public void SetMoveAllowed(bool value) { MoveAllowed = value; }
    public NavMeshAgent GetAgent() { return agent; }
    public ActionSettingsAndEP GetMoveSettings() { return MoveSettings; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        RStatClass MoveParams = new RStatClass(0, 6, 2f);                //TODO - убрать константы в конструктор
        RStatClass MovePrice  = new RStatClass(-0.005f, +0.03f, 0.01f);  //TODO - убрать константы в конструктор

        MoveSettings = new ActionSettingsAndEP(MoveParams, MovePrice);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTargetNearPortal()
    {
        if( Vector2.Distance(this.transform.position,Vector2.zero)>this.GetComponent<EnemyAggressionHandler>().GetRaiusVisualSearch())
        {

            TargetWaypoint = new Vector2(Random.Range(-spreadToSetTargetPoint, spreadToSetTargetPoint),
                                         Random.Range(-spreadToSetTargetPoint, spreadToSetTargetPoint));
        }
        HaveWayPoint = true;
    }

    public void WaypointReached()
    {
        HaveWayPoint = false;
        TargetWaypoint = new Vector2(0, 0);
    }
}
