using UnityEngine;

public class hAgressionController : MonoBehaviour
{
    [SerializeField] private GameObject targetEnemy;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float stedAndAttack = 2; // multiplayer to attackdistance
    [SerializeField] private float chargeRange = 5f;

                     private ActionSettingsAndEP attackRateSettings;

    public GameObject TargetEnemy { get => targetEnemy; set => targetEnemy = value; }
    public float AttackDistance { get => attackDistance; set => attackDistance = value; }
    public float StedAndAttack { get => stedAndAttack; set => stedAndAttack = value; }
    public float ChargeRange { get => chargeRange; set => chargeRange = value; }
    public ActionSettingsAndEP AttackRateSettings { get => attackRateSettings; set => attackRateSettings = value; }

    private void Start()
    {
        RStatClass MoveParams = new RStatClass(0, 3, 1);                 //TODO - убрать константы в конструктор
        RStatClass MovePrice = new RStatClass(0.5f, +3f, 1f);  //TODO - убрать константы в конструктор

        attackRateSettings = new ActionSettingsAndEP(MoveParams, MovePrice);
    }

    public float GetDistanceToEnemy()
    {
        if (TargetEnemy != null)
        {
            return Vector2.Distance(this.transform.position, targetEnemy.transform.position);
        }
        return 0;
    }
}
