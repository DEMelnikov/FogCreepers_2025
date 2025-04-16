using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.EventSystems.EventTrigger;

public class HStateCharge : HeroState
{

    private float savePreviousActualSpeed;
    private HeroStatController statController;
    private Transform TargetTransform;
    private Attack attack;
    private Enemy enemy;
    [SerializeField] private float chargeDMGMultiplayer = 1.5f;
    [SerializeField] private float chargeEPMultiplayer = 1.5f;

    public HStateCharge(Hero hero, HeroStateMaschine heroStateMaschine) : base(hero, heroStateMaschine)
    {
        attack = new Attack(hero);
    }

    public override void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        Debug.Log(base.hero.name + " Enter State Charge");

        if (!CheckEnemy()) { base.hero.StateMaschine.ChangeState(base.hero.IdleState); }

        if (base.hero.GetAgressionController().TargetEnemy.transform == null)
        {
            base.hero.StateMaschine.ChangeState(hero.IdleState);
        }

        TargetTransform = base.hero.GetAgressionController().TargetEnemy.transform;

        statController = base.hero.GetHeroStats();

        savePreviousActualSpeed = statController.MoveSettings.GetPriceActualPercent();//GetMoveSettings().GetActionActualPercent();
        statController.MoveSettings.SetCombinedByPercent(1);

        UpdateDestination();
    }

    private void UpdateDestination()
    {
        if (!CheckEnemy()) { base.hero.StateMaschine.ChangeState(base.hero.IdleState); }

        base.hero.GetComponent<Hero>().GetAgent().destination = TargetTransform.position;
        base.hero.GetComponent<Hero>().GetAgent().speed = statController.MoveSettings.GetActionActual();
    }

    public override void ExitState()
    {
        statController.MoveSettings.SetCombinedByPercent(savePreviousActualSpeed);
        base.hero.GetComponent<Hero>().GetAgent().isStopped = true;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicUpdate()
    {
        UpdateDestination();

        if (base.hero.GetComponent<Hero>().GetAgent().remainingDistance <=
                base.hero.GetAgressionController().AttackDistance)
        {
            base.hero.GetComponent<Hero>().GetAgent().isStopped = true;

            Debug.Log("Hero's Charge Attack!!! distance = " + base.hero.GetComponent<Hero>().GetAgent().remainingDistance
                + " Speed = " + statController.MoveSettings.GetActionActual());

            float attackRoll = attack.Charge();
            float defenceRoll = enemy.GetDefence().DefaultDefence();

            if (attackRoll > defenceRoll)
            {
                float damage = UnityEngine.Random.Range(0.1f, (hero.GetAgressionController().MaxDamage 
                    + hero.GetHeroStats().GetStrenght().Temp) * chargeDMGMultiplayer * -1);

                Debug.Log("Charge dmage = " + damage);
                enemy.GotDamage(damage);
            }
            else
            {
                Debug.Log("Charge no dmage");
            }

            base.hero.StateMaschine.ChangeState(base.hero.AttackState);
            this.hero.GetHeroStats().ChangeEnergy(hero.GetAgressionController().AttackRateSettings.GetPriceActual() * chargeEPMultiplayer * - 1);
        }
        else 
        {
            if (base.hero.GetComponent<Hero>().GetAgent().remainingDistance >
                hero.GetAgressionController().AttackDistance * hero.GetAgressionController().ChargeRange)
            {
                base.hero.StateMaschine.ChangeState(base.hero.IdleState);
            }
            else if (IsPause.GetPauseState())
            {
                base.hero.GetComponent<Hero>().GetAgent().isStopped = true;
            }
            else
            {
                UpdateEnergyByMove();
                base.hero.GetComponent<Hero>().GetAgent().isStopped = false;
            }
        }
    }

    private bool CheckEnemy()
    {
        enemy = null;
        enemy = base.hero.GetAgressionController().TargetEnemy?.GetComponent<Enemy>();
        if (enemy == null) { return false; }
        return true;
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
