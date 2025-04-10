using UnityEngine;
using UnityEngine.UI;

public class EnemyUIPanel : MonoBehaviour
{

    [SerializeField] private GameObject HealthSlider;
    [SerializeField] private GameObject EnergySlider;
    [SerializeField] private GameObject CounterSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RaidGlobals.GetSelectedObject()!=null)
        {
            Enemy enemy = RaidGlobals.GetSelectedObject().GetComponent<Enemy>();
            if(RaidGlobals.SelectedObjectIsEnemy())
            {
                //Debug.Log("Yeah u are krasavcheg");
                HealthSlider.GetComponent<SliderData>().SetMaxValue(enemy.GetEStatHandler().GetHealth());
                HealthSlider.GetComponent<SliderData>().SetSlider  (enemy.GetEStatHandler().GetHealth());

                EnergySlider.GetComponent<SliderData>().SetMaxValue(enemy.GetEStatHandler().GetEnergy());
                EnergySlider.GetComponent<SliderData>().SetSlider  (enemy.GetEStatHandler().GetEnergy());

                if (enemy.StateMaschine.CurrentState == enemy.RegularAttackState)
                {
                    CounterSlider.GetComponentInChildren<Slider>().value =( 1-enemy.RegularAttackState.GetCountdownLeft());
                }
            }
        }
    }
}
