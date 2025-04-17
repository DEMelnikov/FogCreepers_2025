using UnityEngine;

public class HeroStateRestoreEnergy : HeroState
{
    public HeroStateRestoreEnergy(Hero hero, HeroStateMaschine heroStateMaschine) : base(hero, heroStateMaschine)
    {
    }

    public override void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        Debug.Log(base.hero.name + "enter State Restore energy");
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
        return "RestoreEnergy";
    }

    public override void PhysicUpdate()
    {
        if (!IsPause.GetPauseState())
        {
            hero.GetHeroStats().ChangeEnergy(
                hero.GetHeroStats().GetRestoreEnergyEP());

            if (hero.GetHeroStats().GetEnergy().GetPercent() >
                hero.GetHeroStats().GetTargetEnergyToRestore())
            {
                base.hero.StateMaschine.ChangeState(base.hero.GetStateIdle());
            }
        }
    }
}
