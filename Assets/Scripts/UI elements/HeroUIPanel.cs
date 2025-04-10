using System;
using UnityEngine;

public class HeroUIPanel : MonoBehaviour
{
    //[SerializeField] private Hero SelectedHero;
    [SerializeField] private GameObject HealthSlider;
    [SerializeField] private GameObject EnergySlider;
    [SerializeField] private GameObject WillSlider; 

    //private GameObject[] heroes;
    private void Awake()
    {
        if (RaidGlobals.GetSelectedObject() != null && RaidGlobals.GetSelectedObject().tag == "Hero") { UpdatePanels(); }
    }

    //public void SetSelectedHero(Hero hero)
    //{
    //    SelectedHero = hero;
    //}

    //public Hero GetSelectedHero() {return SelectedHero;}

    public void UpdatePanels()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();

            if (hero.tag == "Hero")
            {
                //Debug.Log("Yeah u are krasavcheg");
                HealthSlider.GetComponent<SliderData>().SetMaxValue(hero.GetHeroStats().GetHealth());
                HealthSlider.GetComponent<SliderData>().SetSlider(hero.GetHeroStats().GetHealth());

                EnergySlider.GetComponent<SliderData>().SetMaxValue(hero.GetHeroStats().GetEnergy());
                EnergySlider.GetComponent<SliderData>().SetSlider(hero.GetHeroStats().GetEnergy());

                WillSlider.GetComponent<SliderData>().SetMaxValue(hero.GetHeroStats().GetWill());
                WillSlider.GetComponent<SliderData>().SetSlider(hero.GetHeroStats().GetWill());
            }
        }
    }

    public void UpdateEnergySlider()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();

            if (hero.tag == "Hero")
            {               
                EnergySlider.GetComponent<SliderData>().SetMaxValue(hero.GetHeroStats().GetEnergy());
                EnergySlider.GetComponent<SliderData>().SetSlider(hero.GetHeroStats().GetEnergy());
            }
        }
    }
}
