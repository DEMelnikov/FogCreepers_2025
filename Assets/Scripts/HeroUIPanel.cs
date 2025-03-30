using System;
using UnityEngine;

public class HeroUIPanel : MonoBehaviour
{
    [SerializeField] private Hero SelectedHero;
    [SerializeField] private GameObject HealthSlider;
    [SerializeField] private GameObject EnergySlider;
    [SerializeField] private GameObject WillSlider; 

    private GameObject[] heroes;
    private void Awake()
    {
        if (SelectedHero != null) { UpdatePanels(SelectedHero); }
    }   

    public void SetSelectedHero(Hero hero)
    {
        SelectedHero = hero;
    }

    public void UpdatePanels(Hero hero)
    {
        if (hero.tag == "Hero") 
        {
            Debug.Log("Yeah u are krasavcheg");
            HealthSlider.GetComponent<SliderData>().SetMaxValue(hero.GetComponent<HeroStatController>().GetHealth());
            HealthSlider.GetComponent<SliderData>().SetSlider  (hero.GetComponent<HeroStatController>().GetHealth());

            EnergySlider.GetComponent<SliderData>().SetMaxValue(hero.GetComponent<HeroStatController>().GetEnergy());
            EnergySlider.GetComponent<SliderData>().SetSlider(hero.GetComponent<HeroStatController>().GetEnergy());

            WillSlider.GetComponent<SliderData>().SetMaxValue(hero.GetComponent<HeroStatController>().GetWill());
            WillSlider.GetComponent<SliderData>().SetSlider(hero.GetComponent<HeroStatController>().GetWill());
        }
    }
}
