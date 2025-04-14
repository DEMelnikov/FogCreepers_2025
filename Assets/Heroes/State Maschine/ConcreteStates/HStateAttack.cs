using UnityEngine;

public class HStateAttack : HeroState
{
    private Enemy enemy;
    private hAgressionController agressionController;
    private float attackRange;
    private float stepAndHitRange;
    private float chargeRange;

    public HStateAttack(Hero hero, HeroStateMaschine heroStateMaschine) : base(hero, heroStateMaschine)
    {
    }

    public override void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        agressionController = base.hero.GetAgressionController();
        if (!CheckEnemy()) { base.hero.StateMaschine.ChangeState(base.hero.IdleState); }

        attackRange     = agressionController.AttackDistance;
        stepAndHitRange = attackRange * agressionController.StedAndAttack;
        chargeRange     = attackRange * agressionController.ChargeRange;

        Debug.Log(this.hero.name + "  enters state Attack");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicUpdate()
    {
        if (!CheckEnemy()) { base.hero.StateMaschine.ChangeState(base.hero.IdleState); }

        if (!IsPause.GetPauseState())
        {
            if (agressionController.GetDistanceToEnemy()<=attackRange ) 
            {
                //default attack
                return;
            }

            if (agressionController.GetDistanceToEnemy() > attackRange && agressionController.GetDistanceToEnemy() < stepAndHitRange)
            {
                //step n hit attack
                return;
            }

            if (agressionController.GetDistanceToEnemy() >= stepAndHitRange  && agressionController.GetDistanceToEnemy() < chargeRange)
            {
                //charge
                return;
            }


            // close to enemy


            return;
        }
        else { return; }
    }

    private bool CheckEnemy()
    {
        enemy = null;
        enemy = agressionController.TargetEnemy.GetComponent<Enemy>();
        if (enemy == null) { return false; }
        return true;
    }


}
