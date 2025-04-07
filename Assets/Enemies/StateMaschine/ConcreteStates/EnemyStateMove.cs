using UnityEngine;

public class EnemyStateMove : EnemyState
{
    private bool stopAtTurnEnd;

    public EnemyStateMove(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {
        StopAtTurnEnd = false;
        //TurnsCounter.onNewTurn += OnNewTurn;
    }

    public bool StopAtTurnEnd { get => stopAtTurnEnd; set => stopAtTurnEnd = value; }

    public override void EnterState()
    {
        Debug.Log("enter move State");
        TurnsCounter.onNewTurn += OnNewTurn;
        ResetDestinaton();
    }

    public override void ExitState()
    {
        if (StopAtTurnEnd)
        {
            StopAtTurnEnd = false;
            enemy.GetComponent<EnemyMoveHandler>().SetHaveWaypoint(false);
        }
        TurnsCounter.onNewTurn -= OnNewTurn;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override string GetStateName()
    {
        return "Move";
    }

    public override void PhysicUpdate()
    {
        if (base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().remainingDistance <=
            base.enemy.GetComponent<EnemyMoveHandler>().ObjectCloseRange)
        {
            base.enemy.GetComponent<EnemyMoveHandler>().WaypointReached();
            base.enemy.StateMaschine.ChangeState(enemy.IdleState);
        }

        if (IsPause.GetPauseState())
        {
            base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().isStopped = true;
        }
        else
        {
            if (base.enemy.GetComponent<EnemyMoveHandler>().GetMoveAllowed())
            {
                base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().isStopped = false;
                //updateenergy
            }
            else
            {
                base.enemy.StateMaschine.ChangeState(enemy.IdleState);
            }
        }
    }

    public void ResetDestinaton()
    {
        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().destination =
            enemy.GetComponent<EnemyMoveHandler>().GetTargetWaypoint();

        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().speed =
            enemy.GetComponent<EnemyMoveHandler>().GetMoveSettings().GetActionActual();
    }

    private void OnNewTurn()
    {
        if (StopAtTurnEnd)
        {
            base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().isStopped = true;
            base.enemy.StateMaschine.ChangeState(enemy.IdleState);
        }
    }
   
}
