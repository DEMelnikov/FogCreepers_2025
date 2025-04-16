using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackRateSettingsSlider : MonoBehaviour
{
    //[SerializeField] private GameObject EPTextUI;

    private void OnEnable()
    {
        UpdateSlider();
    }

    public void OnValueChange()
    {
        if (RaidGlobals.GetSelectedObject())
        {

            if (RaidGlobals.SelectedObjectIsHero())
            {
                ActionSettingsAndEP AttackRate = RaidGlobals.GetSelectedObject().GetComponent<Hero>().
                    GetAgressionController().AttackRateSettings;

                AttackRate.SetCombinedByPercent(this.GetComponent<Slider>().value);

                RaidGlobals.GetSelectedObject().GetComponent<Hero>().
                   GetAgressionController().AttackRateSettings.SetCombinedByPercent(1-this.GetComponent<Slider>().value);
                Debug.Log("New attack rate = " + this.GetComponent<Slider>().value);

                if (RaidGlobals.GetSelectedObject().GetComponent<Hero>().StateMaschine.CurrentHeroState ==
                        RaidGlobals.GetSelectedObject().GetComponent<Hero>().AttackState)
                {
                    RaidGlobals.GetSelectedObject().GetComponent<Hero>().AttackState.SetNewAttackRate(
                        RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetAgressionController().AttackRateSettings.GetActionActual());

                    //Debug.Log("new attack rate set at attak state = " + this.GetComponent<Slider>().value);
                }
                //if (RaidGlobals.GetSelectedObject().GetComponent<Hero>().StateMaschine.CurrentHeroState ==
                //    RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetStateMoving())
                //{
                //    RaidGlobals.GetSelectedObject().GetComponent<Hero>().GetStateMoving().UpdateSpeed();
                //}
            }
        }
    }

    public void UpdateSlider()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            if (RaidGlobals.SelectedObjectIsHero())
            {
                ActionSettingsAndEP AttackRate = RaidGlobals.GetSelectedObject().GetComponent<Hero>().
                    GetAgressionController().AttackRateSettings;

                this.GetComponent<Slider>().value = AttackRate.GetActionActualPercent();


                //this.GetComponent<Slider>().value = 0;
               Debug.Log("Attack rate in fight pannel trying set to = " + AttackRate.GetActionActualPercent());
            }
        }
    }
}
