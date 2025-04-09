using UnityEngine;

public class EnemyStateAttackRegular : EnemyState

{
    private EnemyAggressionHandler enemyAgro;
    private Countdown attackCountdown;
    public EnemyStateAttackRegular(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Enter regular attack state");
        enemyAgro = this.enemy.GetComponent<EnemyAggressionHandler>();
        enemyAgro.GetRegularAttackSrttings().SetCombinedByPercent(Random.Range(0.1f, 1));

        attackCountdown = new(enemyAgro.GetRegularAttackSrttings().GetActionActual(), false);

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
        return base.GetStateName();
    }

    public override void PhysicUpdate()
    {
        if (base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero() == null)
        {
            Debug.Log("exit state cause Target hero " + base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().name);
            base.enemy.StateMaschine.ChangeState(enemy.IdleState);
            return;
        }

        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().destination = 
            base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().transform.position;

        if (base.enemy.GetComponent<EnemyAggressionHandler>().AttackDistance <
            enemy.GetComponent<EnemyMoveHandler>().GetAgent().remainingDistance)
        {
            Debug.Log("exit cause remaining dist " + enemy.GetComponent<EnemyMoveHandler>().GetAgent().remainingDistance);
            base.enemy.StateMaschine.ChangeState(enemy.IdleState);
            return;
        }


        if (attackCountdown.UpdateCountdown())
        {
            float attackRoll = enemy.GetAttack().DefaultAttack();
            Debug.Log("Regular Attack roll = " + attackRoll);

            float defRoll = base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().
            GetComponent<Hero>().GetDefence().DefaultDefence();
            Debug.Log("Regular Defence roll = " + defRoll);

            if (attackRoll > defRoll)
            {
                Debug.Log("Success attack");
            }
            else
            {
                Debug.Log("Unsuccess attack");
            }

        }

    }
}
