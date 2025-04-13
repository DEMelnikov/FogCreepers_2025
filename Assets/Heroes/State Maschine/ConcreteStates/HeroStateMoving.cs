using UnityEngine;

public class HeroStateMoving : HeroState
{
    //private bool isTakingBreath=false;

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
        base.hero.GetAgent().isStopped = true;
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
        // Debug.Log("Update - i'm moving" + base.hero.name + base.hero.GetAgent().remainingDistance.ToString());

        if (base.hero.GetAgent().remainingDistance <= 2)
        {
            base.hero.GetHeroStats().WaypointReached();
            base.hero.StateMaschine.ChangeState(base.hero.GetStateIdle());
        }

        if (IsPause.GetPauseState())
        { 
            base.hero.GetAgent().isStopped = true;
            //base.hero.StateMaschine.ChangeState(base.hero.GetStateIdle());
        }
        else
        {
            if (hero.GetHeroStats().GetMoveAllowed())
            {
                base.hero.GetAgent().isStopped = false;

                //Debug.Log("Update - Hero's moving " + base.hero.name + " Speed: " + base.hero.GetAgent().speed
                //     + " Distance: " + base.hero.GetAgent().remainingDistance.ToString()+" Aloowed "+
                //     hero.GetComponent<HeroStatController>().GetMoveAllowed().ToString());

                UpdateEnergyByMove();
            }
            else
            {
                base.hero.StateMaschine.ChangeState(base.hero.GetStateIdle());
            }
        }

            base.PhysicUpdate();
    }

    public void ResetDestinaton()
    {
        base.hero.GetAgent().destination = base.hero.GetHeroStats().GetTargetWaypoint();
        base.hero.GetAgent().speed = base.hero.GetHeroStats().MoveSettings.GetActionActual();
          
    }

    public void UpdateSpeed()
    {
        base.hero.GetAgent().speed = base.hero.GetHeroStats().MoveSettings.GetActionActual();
    }

    public void UpdateEnergyByMove()
    {
        hero.GetHeroStats().ChangeEnergy(hero.GetHeroStats().MoveSettings.GetPriceActual() * -1);
       
        if (hero.GetHeroStats().GetEnergy().GetPercent() <= hero.GetHeroStats().GetCriticalLevelEnergy())
        {
            base.hero.StateMaschine.ChangeState(base.hero.GetStateRestoreEnergy());
        }

    }




}
