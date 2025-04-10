using System;
using UnityEngine;

public class DownPanelUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject HeroUIPanel;
    [SerializeField] private GameObject MoveButton;
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

    private void Update()
    {
        if (RaidGlobals.GetSelectedObject() != null && RaidGlobals.GetSelectedObject().tag == "Hero")
        {
            //UpdatePanels();
            HeroUIPanel.GetComponent<HeroUIPanel>().UpdateEnergySlider();
        }    
    }

    private void SelectionIsHero(Hero hero)
    {
        UpdatePanels();
    }

    public void UpdatePanels()
    {
        HeroUIPanel.SetActive(true);
        HeroUIPanel.GetComponent<HeroUIPanel>().UpdatePanels();
        MoveButton.GetComponent<MoveActionButton>().UpDateButtons();
    }
}
