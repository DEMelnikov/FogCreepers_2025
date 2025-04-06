using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected StateMaschine StateMaschine;

    public EnemyState(Enemy enemy, StateMaschine StateMaschine)
    {
        this.enemy = enemy;
        this.StateMaschine = StateMaschine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicUpdate() { }
    //public virtual void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType) { }
    public virtual string GetStateName() { return ""; }



}
