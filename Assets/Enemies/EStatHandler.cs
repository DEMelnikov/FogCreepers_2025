using UnityEngine;

public class EStatHandler : MonoBehaviour
{
    private StatClass Health;
    private StatClass Energy;

    [SerializeField] private float RestoreEnergyEP = 0.015f;
    [SerializeField] private float TargetEnergyToRestore = 0.25f;
    [SerializeField] private float CriticalLevelEnergy = 0.1f;

    private void Awake()
    {
        float randomStat = Random.Range(5, 30);
        Health = new StatClass(0, randomStat, randomStat, randomStat);
        Energy = new StatClass(0, 100, 100, 100);
    }
    public StatClass GetHealth() { return Health; }
    public StatClass GetEnergy() { return Energy; }
}
