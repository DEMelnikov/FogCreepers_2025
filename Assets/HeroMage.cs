using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class HeroMage : UnitBase
        

{
    [SerializeField]
    //public float DeafaultSpeed = 0.1f;

    private bool RuneKnown = false;
    private GameObject KnownRune;
    public float step;

    //private Vector2 TargetPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetStep(DeafaultSpeed);
        stopRadius = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        SwitchAction();

    }
    private HeroActivities SetNewActivity()
    {
        HeroActivities NewActivity;

        if (ActiveAction == HeroActivities.idle && RuneKnown == false)
        {
            NewActivity = HeroActivities.reuneExpore;
            print("Mage action is Rune Expolore");
            TargetPoint = GetTaregetPointExporeMode();
        }
        else if (ActiveAction == HeroActivities.idle && RuneKnown == true)
        {
            print("Explore is over - start listen - closing");
            NewActivity = HeroActivities.runeListen;
        }
        else NewActivity = HeroActivities.idle;

            return NewActivity;
    }

    private void ExploreMapForRunes()
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
                Move();
            }
        }
    }

    public void SetStep(float speed)
    {
        step = speed * Time.deltaTime;
        //print($"step is now {step}");
    }

    public void RuneKnownSwitch (bool runeStatus)
    {
        RuneKnown = runeStatus;
    }

    public void SetKnownRune(GameObject rune)
    {
        KnownRune = rune;
    }

    public void SwitchAction()
    {
        if (ActiveAction == HeroActivities.idle)
        {
            ActiveAction = SetNewActivity(); return;
        }
        if (ActiveAction == HeroActivities.reuneExpore)
        {
            SetStep(DeafaultSpeed);
            ExploreMapForRunes();return;
        }
        if (ActiveAction == HeroActivities.runeListen)
        {
            SetTargetPoint(new Vector2(KnownRune.transform.position.x, KnownRune.transform.position.y));
            SetStep(DeafaultSpeed);
            //print($"Set step is now = {step} by ds {DeafaultSpeed}");
            //TargetPoint = new Vector2(KnownRune.transform.position.x, KnownRune.transform.position.y);
            RuneListen(); return;
        }
    }

    private void RuneListen()
    {
        if (Vector2.Distance(transform.position, TargetPoint) <= stopRadius)
        {
            SetStep(0);
        }
        else
        {
            //print($"Stop cause range {Vector2.Distance(transform.position, TargetPoint)} and stop range is {stopRadius}");
            Move();
        }

    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, step);
    }


}
