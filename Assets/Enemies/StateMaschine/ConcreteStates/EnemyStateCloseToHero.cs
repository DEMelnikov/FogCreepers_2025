using System;
using UnityEngine;

public class EnemyStateCloseToHero : EnemyState
{
    private Transform TargetHeroTransform;

    public EnemyStateCloseToHero(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {

    }

    public override void EnterState()
    {
        Debug.Log(base.enemy.name + " Enter State Close to hero");
        if (base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().transform != null)
        {
            TargetHeroTransform = base.enemy.GetComponent<EnemyAggressionHandler>().GetTargetHero().transform;
        }
        UpdateDestination();
    }


    public override void ExitState()
    {
        TargetHeroTransform = null;
        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().isStopped = true;
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override string GetStateName()
    {
        return "ClosingToHero";
    }

    public override void PhysicUpdate()
    {
        UpdateDestination();
        if (base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().remainingDistance <=
                 base.enemy.GetComponent<EnemyAggressionHandler>().ChargeDistance)
        {
            // TODO - go to State Charge or Attack
            //Debug.Log("CHAAAARGE"!);

            base.enemy.StateMaschine.ChangeState(enemy.ChargeState);

        }
        else
        {

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
                // Update target?
            }
            else
            {
                base.enemy.StateMaschine.ChangeState(enemy.IdleState);
            }
        }

    }


    private void UpdateDestination()
    {
        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().destination = TargetHeroTransform.position;
        base.enemy.GetComponent<EnemyMoveHandler>().GetAgent().speed =
            enemy.GetComponent<EnemyMoveHandler>().GetMoveSettings().GetActionActual();
    }
}
