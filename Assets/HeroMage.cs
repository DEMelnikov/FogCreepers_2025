using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.Collections.Unicode;

public class HeroMage : UnitBase
        

{
    [SerializeField]
    //public float DeafaultSpeed = 0.1f;

    private bool RuneKnown = false;
    private GameObject KnownRune;
    public float step;
    public int RuneListenSkill = 5;
    public int RuneListenSpeed = 5;

    public float RuneSkillDelayCounter;

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
            SetTargetPoint(new Vector2(KnownRune.transform.position.x, KnownRune.transform.position.y));
            SetStep(DeafaultSpeed);
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
            // SetTargetPoint(new Vector2(KnownRune.transform.position.x, KnownRune.transform.position.y));
            //SetStep(DeafaultSpeed);
            //print($"Set step is now = {step} by ds {DeafaultSpeed}");
            //TargetPoint = new Vector2(KnownRune.transform.position.x, KnownRune.transform.position.y);
            RuneListen(); return;
        }
    }

    private void RuneListen()
    {
        //print($"Stop cause range {Vector2.Distance(transform.position, TargetPoint)} and stop range is {stopRadius}");

        if (Vector2.Distance(transform.position, TargetPoint) <= stopRadius && step>0)
        {
            //print($"Stop chikibarum range {Vector2.Distance(transform.position, TargetPoint)} and stop range is {stopRadius} step is {step}" );
            //print($"Stop chikibarum step is {step}");
            SetStep(0);
            SetRuneDelayCounter(KnownRune);
           // print($"Stop chikibarum step is {step}");
        }
        else if (Vector2.Distance(transform.position, TargetPoint) > stopRadius)
        {
            print($"Stop cause range {Vector2.Distance(transform.position, TargetPoint)} and stop range is {stopRadius}");
            Move();
        }
        else
        {
            print("trying to resolve");
            RuneSkillDelayCounter = RuneSkillDelayCounter - RuneListenSpeed * Time.deltaTime;
            TryToResolveRune(RuneSkillDelayCounter);
        }


    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, step);
    }

    private void TryToResolveRune(float timer)
    {


        if (timer<=0)
        {
            if (SkillCheckVSRune(KnownRune))
            {
                print("Success check");
            }
            else print("Unsuccess check");
            SetRuneDelayCounter(KnownRune);
        }
    }

    private bool SkillCheckVSRune(GameObject rune)
    {
        int SkillCheckDice = 20;

        bool checkResult = false;
        if (RuneListenSkill+Random.Range(1,SkillCheckDice) > rune.GetComponent<RuneData>().GetRuneDC())
        {
            checkResult = true;
        }
        return checkResult;
    }

    private void SetRuneDelayCounter(GameObject rune)
    {
        RuneSkillDelayCounter = rune.GetComponent<RuneData>().GetDelayCounter();
    }

}
