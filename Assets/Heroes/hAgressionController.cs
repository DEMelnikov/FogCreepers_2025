using UnityEngine;

public class hAgressionController : MonoBehaviour
{
    [SerializeField] private GameObject targetEnemy;
    [SerializeField] private float attackDistance = 2f;

    public GameObject TargetEnemy { get => targetEnemy; set => targetEnemy = value; }
    public float AttackDistance { get => attackDistance; set => attackDistance = value; }

    public float GetDistanceToEnemy()
    {
        if (TargetEnemy != null)
        {
            return Vector2.Distance(this.transform.position, targetEnemy.transform.position);
        }
        return 0;
    }
}
