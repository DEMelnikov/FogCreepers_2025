using UnityEngine;

public class HStateAttack : HeroState
{
    private Enemy enemy;
    private hAgressionController agressionController;
    //private float distance;
    private float attackRange;
    private float stepAndHitRange;
    private float chargeRange;

    private Attack attack;
    private Countdown attackCountdown;

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

        attack = new Attack(this.hero.GetComponent<Hero>());
        attackCountdown = new Countdown(agressionController.AttackRateSettings.GetActionActual(), false);
        attackCountdown.SetCountdownToReady();

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
            float distance = agressionController.GetDistanceToEnemy();

            if (attackCountdown.UpdateCountdown())
            {
                if (distance <= attackRange && agressionController.AllowAttack)
                {
                    float attackRoll = attack.DefaultAttack();
                    float defenceRoll = enemy.GetDefence().DefaultDefence();

                    Debug.Log("Hero makes default attack " + attackRoll+ " vs defence " + defenceRoll);

                    if (attackRoll > defenceRoll) 
                    {
                        float damage = Random.Range(0.1f, hero.GetAgressionController().MaxDamage 
                            + hero.GetHeroStats().GetStrenght().Temp * -1);

                        //enemy.GetEStatHandler().GetHealth().ChangeActual(damage);  
                        enemy.GotDamage(damage);
                    } 

                    this.hero.GetHeroStats().ChangeEnergy(agressionController.AttackRateSettings.GetPriceActual()*-1);
                    return;
                }

                if (distance > attackRange && distance < stepAndHitRange && agressionController.AllowStepNHit)
                {
                    //step n hit attack
                    Vector2 StepDirection = (enemy.transform.position - hero.transform.position).normalized;
                    hero.RB.AddForce(StepDirection, ForceMode2D.Impulse);

                    float attackRoll = attack.DefaultAttack();
                    float defenceRoll = enemy.GetDefence().DefaultDefence();

                    Debug.Log("Hero Step n Hit attack " + attackRoll + " vs defence " + defenceRoll);

                    if (attackRoll > defenceRoll)
                    {
                        float damage = Random.Range(0.1f, hero.GetAgressionController().MaxDamage
                            + hero.GetHeroStats().GetStrenght().Temp * -1);

                        //enemy.GetEStatHandler().GetHealth().ChangeActual(damage);  
                        enemy.GotDamage(damage);
                    }

                    this.hero.GetHeroStats().ChangeEnergy(agressionController.AttackRateSettings.GetPriceActual() * -1);


                    return;
                }
            }

            if (distance >= stepAndHitRange && distance < chargeRange)
            {
                base.hero.StateMaschine.ChangeState(base.hero.ChargeState);
                return;
            }
            // close to enemy or Controll Distance


            return;
        }
        else { return; }
    }

    private bool CheckEnemy()
    {
        enemy = null;
        enemy = agressionController.TargetEnemy?.GetComponent<Enemy>();
        if (enemy == null) { return false; }
        return true;
    }

    public void SetNewAttackRate(float rate)
    {
        attackCountdown.SetNewTimeLimit(rate);
    }
}
