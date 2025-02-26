using UnityEngine;
using UnityEngine.AI;

using static UnityEngine.RuleTile.TilingRuleOutput;

public class HeroEploreRunesState : HeroState
{
    private MapGlobalActions map;
    private Vector2 targetPoint;
    private NavMeshAgent agent;

    public HeroEploreRunesState(Hero hero, HeroStateMaschine heroStateMaschine) : base(hero, heroStateMaschine)
    {
        map = new MapGlobalActions();
    }

    public override void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        agent = hero.GetComponent<NavMeshAgent>();
        Debug.Log("Start Exploring");
        Vector2 newPoint = map.GetRandomPointWithIndent(true);

        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {


        base.FrameUpdate();
        if (agent.remainingDistance < hero.GetdistanceToChangeGoal())
        {
            agent.destination = GetTaregetPointExporeMode();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    protected Vector2 GetTaregetPointExporeMode()
    {
        int deltaDown = 1, deltaUp = 1, deltaleft = 1, deltaRight = 1;
        float y = hero.GetHeroPosition().position.y;
        float x = hero.GetHeroPosition().position.x;

        float max_width = map.GetMaxWidth();
        float max_height = map.GetMaxHeight();

        if (y - hero.GetRadiusRandomSearch() <= max_height / 2 * -1 && !hero.GetIsFacingUp()) hero.SetIsFacingUp(true);
        if (y + hero.GetRadiusRandomSearch() >= max_height / 2 && hero.GetIsFacingUp()) hero.SetIsFacingUp(false);

        if (x - hero.GetRadiusRandomSearch() <= max_width / 2 * -1 && hero.GetIsFacingRight()) hero.SetIsFacingRight(false);
        if (x + hero.GetRadiusRandomSearch() >= max_width / 2 && !hero.GetIsFacingRight()) hero.SetIsFacingRight(true);

        if (hero.GetIsFacingUp()) deltaDown = 0; else deltaUp = 0;
        if (hero.GetIsFacingRight()) deltaRight = 0; else deltaleft = 0;
        Vector2 targetPoint = new Vector2(
        Random.Range(x - hero.GetRadiusRandomSearch() * deltaleft, (x + hero.GetRadiusRandomSearch() * deltaRight)),
           Random.Range(y - hero.GetRadiusRandomSearch() * deltaDown, y + hero.GetRadiusRandomSearch() * deltaUp));

        return targetPoint;
    }
}
