using UnityEngine;

public class HeroState
{
    protected Hero hero;
    protected HeroStateMaschine heroStateMaschine;

    public HeroState (Hero hero, HeroStateMaschine heroStateMaschine)
    {
        this.hero = hero;
        this.heroStateMaschine = heroStateMaschine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicUpdate() { }
    public virtual void AnimationTriggerEvent(Hero.AnimationTriggerType triggerType) { }



}
