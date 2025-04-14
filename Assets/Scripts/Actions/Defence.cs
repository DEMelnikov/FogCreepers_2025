using UnityEngine;

public class Defence
{
    private Hero  hero;
    private Enemy enemy;

    public Defence(Hero hero)   { this.hero  = hero; }
    public Defence(Enemy enemy) { this.enemy = enemy; }

    public float DefaultDefence()
    {
        return GetDefaultDefenceSkill();
    }

    private float GetDefaultDefenceSkill()
    {
        if (enemy != null) { return enemy.DefaultDefence.Temp; }
        if (hero  != null) { return hero. DefaultDefence.Temp; }
        return 0;
    }
}
