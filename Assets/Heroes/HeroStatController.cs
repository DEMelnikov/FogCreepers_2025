using NUnit.Framework.Constraints;
using UnityEngine;

public class HeroStatController : MonoBehaviour
{
    [SerializeField] private string HeroName;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float maxEnergy = 100;
    [SerializeField] private float maxWill   = 100;
    [SerializeField] private Vector2 TargetWaypoint = new Vector2();

    public StatClass Health;
    public StatClass Energy;
    public StatClass Will;

    private HeroStatController ()
    {
        Health = new StatClass(0, maxHealth, maxHealth, maxHealth);
        Energy = new StatClass(0,maxEnergy, maxEnergy, maxEnergy);
        Will   = new StatClass(0,maxWill, maxWill, maxWill);
    }

    public string GetHeroName()
    {
        return HeroName;
    }

    public Vector2 GetTargetWaypoint()
    {
        return TargetWaypoint;
    }

    public void SetTargerWaypoint(Vector2 newWaypoint)
    {
        TargetWaypoint = newWaypoint;
    }

}
