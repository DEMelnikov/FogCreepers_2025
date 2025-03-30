using NUnit.Framework.Constraints;
using UnityEngine;

public class HeroStatController : MonoBehaviour
{
    [SerializeField] private string HeroName;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float maxEnergy = 100;
    [SerializeField] private float maxWill   = 100;
    [SerializeField] private Vector2 TargetWaypoint = new Vector2();
    [SerializeField] private bool HaveWayPoint = false;
    [SerializeField] private float NewWaypointRadius = 2f;
   // [SerializeField] private GameObject WayPointGhostPrefub;
    [SerializeField] private GameObject WayPointPrefub;

    public StatClass Health;
    public StatClass Energy;
    public StatClass Will;

    private void Awake()
    {
        //WayPointPrefub 
    }
    private HeroStatController ()
    {
      //  int randomInt = Random.Range(0, (int)maxHealth);
        Health = new StatClass(0, maxHealth, 50, maxHealth);
        Energy = new StatClass(0,maxEnergy, 75, maxEnergy);
        Will   = new StatClass(0,maxWill, 25, maxWill);
    }

    public string GetHeroName()  {return HeroName;}

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
    public StatClass GetWill() { return Will; }
    public bool GetHaveWaypoint() { return HaveWayPoint; }

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
