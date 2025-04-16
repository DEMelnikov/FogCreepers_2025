using UnityEngine;

public class LasyEnemyStateIdle : EnemyState
{
    private EnemyMoveHandler enemyMoveHandler;

    public LasyEnemyStateIdle(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {
        enemyMoveHandler = enemy.GetComponent<EnemyMoveHandler>();        
    }


    public override void EnterState()
    {
        Debug.Log("Enemy " + enemy.name + " eneter Idle State");
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
        return "Idle";
        //return base.GetStateName();
    }

    public override void PhysicUpdate()
    {

    }

    private bool IsReadyToMove()
    {
       if (enemyMoveHandler.GetHaveWayPoint() && enemyMoveHandler.GetMoveAllowed())
       {
            return true;
       }         
        return false;
    }


}
