using UnityEngine;

public class hAgressionController : MonoBehaviour
{
    [SerializeField] private GameObject targetEnemy;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float stepAndAttack = 2f; // multiplayer to attackdistance
    [SerializeField] private float chargeRangeMultiplayer = 5f;
    [SerializeField] private float chargeEPLimit = 0.25f;

    [SerializeField] private float maxDamage = 6f;

    [SerializeField] private bool allowAttack = true;
    [SerializeField] private bool allowCharge = true;
    [SerializeField] private bool allowStepNHit = true;



    private ActionSettingsAndEP attackRateSettings;

    public GameObject TargetEnemy { 
        get
        {
            return targetEnemy;
        }
        set
        {
            if (targetEnemy != null) { Debug.Log("Отписка!!!"); targetEnemy.GetComponent<Enemy>().EnemyDead -= ForgetTargetEnemy; }
            targetEnemy = value;
            if (targetEnemy != null) { Debug.Log("Подписка!!!"); targetEnemy.GetComponent<Enemy>().EnemyDead += ForgetTargetEnemy; }
            //value.GetComponent<Enemy>().EnemyDead += 
        }        
    }
    


    //public void SetTargetEnemy { set => targetEnemy = value; }
    public float AttackDistance   { get => attackDistance; set => attackDistance = value; }
    public float StedAndAttack    { get => stepAndAttack; set => stepAndAttack = value; }
    public float ChargeRange      { get => chargeRangeMultiplayer * attackDistance; set => chargeRangeMultiplayer = value; }
    public bool AllowAttack       { get => allowAttack; set => allowAttack = value; }
    public bool AllowCharge       
    { get
        { 
            if(allowCharge && GetComponent<Hero>().GetHeroStats().GetEnergy().GetPercent() >= chargeEPLimit)
            {
                return true;
            }
            else { return false; }
        }
        set => allowCharge = value; 
    }
    public bool AllowStepNHit     { get => allowStepNHit; set => allowStepNHit = value; }
    public float MaxDamage        { get => maxDamage; set => maxDamage = value; }
    public ActionSettingsAndEP AttackRateSettings { get => attackRateSettings; set => attackRateSettings = value; }

    private void Start()
    {
        RStatClass AttackRate = new RStatClass(1f, 4f, 2);    //TODO - убрать константы в конструктор
        RStatClass AttackEP = new RStatClass(0.5f, +3f, 1f);  //TODO - убрать константы в конструктор

        attackRateSettings = new ActionSettingsAndEP(AttackRate, AttackEP);
    }

    public float GetDistanceToEnemy()
    {
        if (TargetEnemy != null)
        {
            return Vector2.Distance(this.transform.position, targetEnemy.transform.position);
        }
        return 0;
    }

    private void ForgetTargetEnemy(Enemy enemy)
    {
        targetEnemy = null;
    }
}
