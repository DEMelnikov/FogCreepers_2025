using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyStateSearchTarget : EnemyState
{
    private EnemyAggressionHandler enemyAggressionHandler;


    public EnemyStateSearchTarget(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {
        enemyAggressionHandler = enemy.GetComponent<EnemyAggressionHandler>();
    }

    public override void EnterState()
    {
        Debug.Log("Start Search State");
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
        
        return "Search";
    }

    public override void PhysicUpdate()
    {
        if ( !IsPause.GetPauseState())
        {
            if (VisualSearch())
            {
                Debug.Log("Visual COntact!!! " + enemyAggressionHandler.GetVisibleHeroes().Count() + " targets ");
                SetTargetFromList();
                this.enemy.StateMaschine.ChangeState(enemy.CloseToHero);
            }
            else
            {
                if (enemyAggressionHandler.IsReadyToAttackPortal)
                {
                    enemy.GetComponent<EnemyMoveHandler>().GenerateTargetNearPortal();
                    enemy.GetComponent<Enemy>().MoveState.StopAtTurnEnd = true;
                    enemy.StateMaschine.ChangeState(enemy.MoveState);
                    Debug.Log("start walk to Portal");
                }
            }
        }

        
        //base.PhysicUpdate();
    }

    public bool VisualSearch()
    {
        enemyAggressionHandler.GetVisibleHeroes().UpdateCollection(enemyAggressionHandler.transform,1);

        if (enemyAggressionHandler.GetVisibleHeroes().Count() == 0)
        {
            return false;
        }
        else { return true; }
    }

    private void SetTargetFromList()
    {
        if (enemyAggressionHandler.GetVisibleHeroes().Count() > 0)
        {
            if (enemyAggressionHandler.GetVisibleHeroes().GetFirst() != null)
            {
                Debug.Log(" My target is now " + enemyAggressionHandler.GetVisibleHeroes().GetFirst().name);
                enemyAggressionHandler.SetTargetHero(enemyAggressionHandler.GetVisibleHeroes().GetFirst());
            }


            //TODO Zone^
            //if (enemyAggressionHandler.CountHeroesInVisualContact() > 1)
            //{
            //    //TODO chose one in any method

            //    //TEMP:
            //    Debug.Log("Get target hero");
            //    base.enemy.GetComponent<EnemyAggressionHandler>().SetTargetHero(
            //        base.enemy.GetComponent<EnemyAggressionHandler>().GetFirstHeroFromVisualList());
            //}
            //else
            //{
            //    Debug.Log("Get target hero");
            //    base.enemy.GetComponent<EnemyAggressionHandler>().SetTargetHero(
            //        base.enemy.GetComponent<EnemyAggressionHandler>().GetFirstHeroFromVisualList());
            //}
        }
    }
}
