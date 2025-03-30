using UnityEngine;

public class HeroStateMoving : HeroState
{
    public HeroStateMoving(Hero hero, HeroStateMaschine heroStateMaschine) : base(hero, heroStateMaschine)
    {
    }

    public override void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        ResetDestinaton();
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override string GetStateName()
    {
        return "Move";
        //base.GetStateName();
    }

    public override void PhysicUpdate()
    {
         Debug.Log("Update - i'm moving" + base.hero.name + base.hero.GetAgent().remainingDistance.ToString());
        //Debug.Log("Update - i'm moving");
        if (base.hero.GetAgent().remainingDistance <= 2) 
        {
            base.hero.GetComponent<HeroStatController>().WaypointReached();
            base.hero.StateMaschine.ChangeState(base.hero.GetStateIdle());            
        }

        if (IsPause.GetPauseState())
        { 
            base.hero.GetAgent().isStopped = true;
        }
        else
        {
            base.hero.GetAgent().isStopped = false; 
        }

            base.PhysicUpdate();
    }

    public void ResetDestinaton()
    {
        base.hero.GetAgent().destination = base.hero.GetComponent<HeroStatController>().GetTargetWaypoint();
    }
}
