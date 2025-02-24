using UnityEngine;

public class HeroMage : UnitBase
        

{
    [SerializeField]
    //public float DeafaultSpeed = 0.1f;

    private bool RuneKnown = false;
    private float step;

    //private Vector2 TargetPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        step = DeafaultSpeed*Time.deltaTime; 
        stopRadius = 5f;

    }

    // Update is called once per frame
    void Update()
    {

        
        if (ActiveAction == HeroActivities.idle)
        {
            ActiveAction=GetNewActivity();
        }
        if (ActiveAction == HeroActivities.runeListen)
        {
            RuneListenAction();
        }


    }
    private HeroActivities GetNewActivity()
    {
        HeroActivities NewActivity;

        if (ActiveAction == HeroActivities.idle & RuneKnown == false)
        {
            NewActivity = HeroActivities.runeListen;
            print("Mage action is Rune Listen");
            TargetPoint= GetTaregetPointExporeMode();
        }
        else
        {
            NewActivity = HeroActivities.idle;
        }

        return NewActivity;
    }

    private void RuneListenAction()
    {
        //print("Start procedure ");

        Vector2 nullPoint = new Vector2(0, 0);

        if (TargetPoint != nullPoint)
        {
           // print($"continue procedure  {Vector2.Distance(transform.position, TargetPoint)}");

            if (Vector2.Distance(transform.position, TargetPoint) <= stopRadius)
            {
                ActiveAction = HeroActivities.idle;
                TargetPoint = new Vector2(0, 0);
                print("Destination reached");
            }

            else
            {
                transform.position = Vector2.MoveTowards(transform.position, TargetPoint, step);
            }
        }
    }



}
