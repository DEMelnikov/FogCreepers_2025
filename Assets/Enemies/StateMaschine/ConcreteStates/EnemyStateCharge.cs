using UnityEngine;

public class EnemyStateCharge : EnemyState
{
    private float savePreviousActualSpeed;
    private EnemyMoveHandler enemyMoveHandler;
    private Transform TargetHeroTransform;

    public EnemyStateCharge(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {
    }

    public override void EnterState()
    {
        Debug.Log(base.enemy.name + " Enter State Charge");

        if (base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().transform == null)
        {
            base.enemy.StateMaschine.ChangeState(enemy.IdleState);
        }

        TargetHeroTransform = base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().transform;

        enemyMoveHandler = base.enemy.GetComponent<EnemyMoveHandler>();

        savePreviousActualSpeed = enemyMoveHandler.GetMoveSettings().GetActionActualPercent();
        enemyMoveHandler.GetMoveSettings().SetCombinedByPercent(1);

        UpdateDestination();
    }

    public override void ExitState()
    {
        enemyMoveHandler.GetMoveSettings().SetCombinedByPercent(savePreviousActualSpeed);
        enemyMoveHandler.GetAgent().isStopped = true;   
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override string GetStateName()
    {
        return "Charge";
    }

    public override void PhysicUpdate()
    {
        UpdateDestination();
        if (enemyMoveHandler.GetAgent().remainingDistance <= 
            base.enemy.GetComponent<EnemyAggressionHandler>().AttackDistance)
        {
            enemyMoveHandler.GetAgent().isStopped = true;

            Debug.Log("Attack!!! distance = " + enemyMoveHandler.GetAgent().remainingDistance + " Speed = "+
                enemy.GetComponent<EnemyMoveHandler>().GetMoveSettings().GetActionActual());

            float attackRoll = enemy.GetAttack().Charge();
            Debug.Log("Attack roll = " + attackRoll);
            float defRoll = base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().
                GetComponent<Hero>().GetDefence().DefaultDefence();
            Debug.Log("Defence roll = " + defRoll);

            if (attackRoll > defRoll)
            {
                Debug.Log("Success attack");
            }
            else 
            {
                Debug.Log("Unsuccess attack");
            }

            base.enemy.StateMaschine.ChangeState(enemy.RegularAttackState);

            //TODO - > to Attack State

            //base.enemy.GetComponent<EnemyMoveHandler>().WaypointReached();
            //base.enemy.StateMaschine.ChangeState(enemy.IdleState);
            return; //temp - remove when get attack state
        }
        if (IsPause.GetPauseState())
        {
            enemyMoveHandler.GetAgent().isStopped = true;
        }
        else
        {

            enemyMoveHandler.GetAgent().isStopped = false;
        }




    }

    private void UpdateDestination()
    {
        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().destination = TargetHeroTransform.position;
        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().speed =
            enemy.GetComponent<EnemyMoveHandler>().GetMoveSettings().GetActionActual();
    }
}
