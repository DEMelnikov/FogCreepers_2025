using UnityEngine;

public interface HeroISDamageable

{
    void Damage(float damageAmount);

    void Die();

    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }


}
