using UnityEngine;

public class EnemyStateCharge : EnemyState
{
    public EnemyStateCharge(Enemy enemy, StateMaschine StateMaschine) : base(enemy, StateMaschine)
    {
    }

    public override void EnterState()
    {
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
        return "Charge";
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
