using UnityEngine;

public class HeroStateMaschine
{
    public HeroState CurrentHeroState { get; set; }
    public void Initialize(HeroState starttingState)
    {
        CurrentHeroState = starttingState;
        CurrentHeroState.EnterState();
    }

    public void ChangeState(HeroState newState)
    {
        CurrentHeroState.ExitState();
        CurrentHeroState = newState;
        CurrentHeroState.EnterState();
    }
}
