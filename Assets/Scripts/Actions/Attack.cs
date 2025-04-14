using UnityEngine;

public class Attack
{
    private Hero hero;
    private Enemy enemy;

    public Attack (Hero hero) { this.hero = hero; }
    public Attack (Enemy enemy) { this.enemy = enemy; }

    public float DefaultAttack( )
    {
        float rollDice = RaidGlobals.RollDefaultDicePlusX(0)
            + GetAttackSkill();

        return rollDice;
    }



    public float Charge (float dXmax, float skillBonus)
    {
        //float rollDice = RaidGlobals.RollDefaultDicePlusX(GetChargeSkill()) + skillBonus;
        return 0;
    }

    public float Charge()
    {
        float rollDice = RaidGlobals.RollDefaultDicePlusX(GetChargeSkill()) 
            + GetStrenght();

        return rollDice;
    }

    private float GetStrenght()
    {
        if (enemy != null)  { return enemy.Strenght.Max;}
        //if (hero != null) { return hero.}
        return 0;
    }

    private float GetChargeSkill()
    {
        if (enemy != null) { return enemy.ChargeSkill.Max; }
        //if (hero != null) { return hero.}
        return 0;
    }

    private float GetAttackSkill()
    {
        if (enemy != null) { return enemy.AttackSkill.Temp; }
        if (hero  != null) { return hero.GetHeroStats().GetAttackSkill().Temp; }
        return 0;
    }
}
