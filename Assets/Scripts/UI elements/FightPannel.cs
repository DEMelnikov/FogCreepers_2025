using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightPannel : MonoBehaviour
{
    [SerializeField] private GameObject selectedHero;
    [SerializeField] private GameObject selectedEnemy;

    private GameObject heroImage;
    private GameObject enemyImage;
    private TMP_Text textDescription;
    private string descriptionText = "";
    [SerializeField] private Slider eHealthSlider;
    [SerializeField] private Slider eEnergySlider;
    //private string 

    private void Start()
    {
        heroImage = this.gameObject.transform.Find("HeroImage").gameObject;
        enemyImage = this.gameObject.transform.Find("EnemyImage").gameObject;
        textDescription = this.gameObject.transform.Find("FightPanelTextDescription").gameObject.GetComponent<TMP_Text>();
        //eHealthSlider = this.gameObject.transform.Find("HealthSlider").gameObject.GetComponent<Slider>(); //    GetComponentInChildren<HealthSlider>()

    }

    private void Awake()
    {
        //heroImage.GetComponent<Image>().sprite = null;
        //enemyImage.GetComponent<Image>().sprite = null; 
    }

    // Update is called once per frame
    void Update()
    {
        if (RaidGlobals.GetSelectedObject() != null)
        {
            if (RaidGlobals.SelectedObjectIsHero())
            {
                selectedHero = RaidGlobals.GetSelectedObject();
                heroImage.GetComponent<Image>().sprite = selectedHero.GetComponent<SpriteRenderer>().sprite;
                selectedEnemy = selectedHero.GetComponent<hAgressionController>().TargetEnemy;

                if (selectedEnemy != null)
                {
                    //enemyImage.GetComponent<Image>().sprite = null;

                    enemyImage.GetComponent<Image>().sprite = selectedHero.GetComponent<hAgressionController>().
                        TargetEnemy.gameObject.GetComponent<SpriteRenderer>().sprite;
                    descriptionText = "Distance to enemy: " +
                        Math.Round(selectedHero.GetComponent<hAgressionController>().GetDistanceToEnemy(), 2).ToString() +
                        " Weapon range: " + selectedHero.GetComponent<hAgressionController>().AttackDistance;
                    
                    eHealthSlider.gameObject.SetActive(true);
                    eEnergySlider.gameObject.SetActive(true);
                    // TODOOOOOO


                    eHealthSlider.value = selectedEnemy.GetComponent<Enemy>().GetEStatHandler().GetHealth().GetPercent();
                    eEnergySlider.value = selectedEnemy.GetComponent<Enemy>().GetEStatHandler().GetEnergy().GetPercent();
                }
                else
                {
                    eHealthSlider.gameObject.SetActive(false);
                    eEnergySlider.gameObject.SetActive(false);
                    enemyImage.GetComponent<Image>().sprite = null;
                }

                    textDescription.SetText(descriptionText);
            }

            else { this.gameObject.SetActive(false); }
        }
    }
}
