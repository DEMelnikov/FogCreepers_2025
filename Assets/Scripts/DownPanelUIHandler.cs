using System;
using UnityEngine;

public class DownPanelUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject HeroUIPanel;
    private GameObject[] heroes;


    public void Awake()
    {
        HeroUIPanel.SetActive(false);

        heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes)
        {
            hero.GetComponent<Hero>().HeroSelected += SelectionIsHero;
        }
    }

    private void SelectionIsHero(Hero hero)
    {
        HeroUIPanel.SetActive(true);
        HeroUIPanel.GetComponent<HeroUIPanel>().SetSelectedHero(hero);
        HeroUIPanel.GetComponent<HeroUIPanel>().UpdatePanels(hero);
    }
}
