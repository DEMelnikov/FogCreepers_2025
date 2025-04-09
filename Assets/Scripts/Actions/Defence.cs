using UnityEngine;

public class Defence
{
    private Hero hero;
    private Enemy enemy;

    public Defence(Hero hero) { this.hero = hero; }
    public Defence(Enemy enemy) { this.enemy = enemy; }

    public float DefaultDefence()
    {
        return GetDefaultDefenceSkill();
    }

    private float GetDefaultDefenceSkill()
    {
        //if (enemy != null) { return enemy.Strenght.Max; }
        if (hero != null) { return hero.DefaultDefence.Max; }
        return 0;
    }
}
