using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnergySettingsSlider : MonoBehaviour
{
    [SerializeField] private GameObject EPTextUI;

    // Update is called once per frame

    private void OnEnable()
    {

        UpdateSlider();
    }
    void Update()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            if (RaidGlobals.SelectedObjectIsHero())
            {
                //Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();
                ActionSettingsAndEP moveSettings = RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetHeroStats().MoveSettings;

                this.GetComponent<Slider>().minValue = 0;// moveSettings.GetActionMin();
                this.GetComponent<Slider>().maxValue = 1; //moveSettings.getActionMax();
                //this.GetComponent<Slider>().value = moveSettings.GetActionActualPercent();
            }
        }
    }

    public void OnValueChange()
    {
        if (RaidGlobals.GetSelectedObject())
        {

            if (RaidGlobals.SelectedObjectIsHero())
            {
                //Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();
                ActionSettingsAndEP moveSettings = RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetHeroStats().MoveSettings;

                moveSettings.SetCombinedByPercent(this.GetComponent<Slider>().value);    //SetActionActual(this.GetComponent<Slider>().value);
                //moveSettings.GetActionActualPercent();
                
                //moveSettings.SetPriceActualInPercent(moveSettings.GetActionActualPercent());

                //hero.GetHeroStats().SetMoveSettingsActual(this.GetComponent<Slider>().value);
                //hero.GetHeroStats().GetMoveEP().SetActualByPercent(
                //hero.GetHeroStats().GetMoveSettings().GetActualInPercentage());

                EPTextUI.GetComponent<TMP_Text>().SetText("EP: " +
                   moveSettings.GetPriceActualPercent().ToString()
                    + "% value: " +
                    moveSettings.GetActionActual().ToString());

                //hero.GetComponent<HeroStatController>().SetMoveSettings()
                //this.GetComponent<Slider>().minValue = moveSettings.GetMin();
                //this.GetComponent<Slider>().maxValue = moveSettings.GetMax();
                //= moveSettings.GetActual();

                if (RaidGlobals.GetSelectedObject().GetComponent<Hero>().StateMaschine.CurrentHeroState ==
                    RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetStateMoving())
                {
                    RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetStateMoving().UpdateSpeed();
                }
            }
        }
    }

    public void UpdateSlider()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            if (RaidGlobals.SelectedObjectIsHero())
            {
                ActionSettingsAndEP moveSettings = RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetHeroStats().MoveSettings;
                this.GetComponent<Slider>().value = moveSettings.GetActionActualPercent()/100;
                Debug.Log("moveSettings.GetActionActualPercent() = "+ moveSettings.GetActionActualPercent());
            }
        }
    }
}
