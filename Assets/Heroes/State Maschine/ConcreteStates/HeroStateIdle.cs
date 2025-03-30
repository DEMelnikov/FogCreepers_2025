using UnityEngine;

public class HeroStateIdle : HeroState
{
    public HeroStateIdle(Hero hero, HeroStateMaschine heroStateMaschine) : base(hero, heroStateMaschine)
    {
    }

    public override void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        Debug.Log("Update - i'm idle" + base.hero.name+ IsPause.GetPauseState());
       if (IsReadyToMove()){ base.hero.StateMaschine.ChangeState(base.hero.GetStateMoving()); }

        base.FrameUpdate();
    }

    public override string GetStateName()
    {
        return "Idle";
       // base.GetStateName();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private bool IsReadyToMove()
    {
        if (base.hero.GetComponent<HeroStatController>().GetHaveWaypoint()) {return true;}
        return false;
    }
}
