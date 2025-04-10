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
       // Debug.Log("Update - i'm idle" + base.hero.name+ IsPause.GetPauseState());


        base.FrameUpdate();
    }

    public override string GetStateName()
    {
        return "Idle";
       // base.GetStateName();
    }

    public override void PhysicUpdate()
    {
        if (IsReadyToMove()) { base.hero.StateMaschine.ChangeState(base.hero.GetStateMoving()); }

        if (!IsPause.GetPauseState())
        {
            //hero.GetComponent<HeroStatController>().ChangeEnergy(
            //    hero.GetComponent<HeroStatController>().GetRestoreEnergyEP());
            hero.GetHeroStats().ChangeEnergy(
                hero.GetHeroStats().GetRestoreEnergyEP());
        }

        base.PhysicUpdate();
    }

    private bool IsReadyToMove()
    {
        if (base.hero.GetHeroStats().GetHaveWaypoint()) {return true;}
        return false;
    }
}
