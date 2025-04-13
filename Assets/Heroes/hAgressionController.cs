using UnityEngine;

public class hAgressionController : MonoBehaviour
{
    [SerializeField] private GameObject targetEnemy;

    public GameObject TargetEnemy { get => targetEnemy; set => targetEnemy = value; }


}
