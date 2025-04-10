using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnergySettingsSlider : MonoBehaviour
{
    [SerializeField] private GameObject EPTextUI;

    // Update is called once per frame
    void Update()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();

            if (hero.tag == "Hero")
            {
                RStatClass moveSettings = hero.GetHeroStats().GetMoveSettings();
                this.GetComponent<Slider>().minValue = moveSettings.GetMin();
                this.GetComponent<Slider>().maxValue = moveSettings.GetMax();
                this.GetComponent<Slider>().value = moveSettings.GetActual();
            }
        }
    }

    public void OnValueChange()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();

            if (hero.tag == "Hero")
            {
                hero.GetHeroStats().SetMoveSettingsActual(this.GetComponent<Slider>().value);
                hero.GetHeroStats().GetMoveEP().SetActualByPercent(
                  hero.GetHeroStats().GetMoveSettings().GetActualInPercentage());

                EPTextUI.GetComponent<TMP_Text>().SetText("EP: "+ 
                    hero.GetHeroStats().GetMoveEP().GetActualInPercentage().ToString()
                    + " value: " +
                    hero.GetHeroStats().GetMoveEP().GetActual().ToString());

                //hero.GetComponent<HeroStatController>().SetMoveSettings()
                //this.GetComponent<Slider>().minValue = moveSettings.GetMin();
                //this.GetComponent<Slider>().maxValue = moveSettings.GetMax();
                //= moveSettings.GetActual();

                 if (hero.StateMaschine.CurrentHeroState.GetStateName() == "Move") 
                { 
                    hero.GetComponent<Hero>().GetStateMoving().UpdateSpeed();
                }
            }
        }
    }
}
