using System;
using UnityEngine;

public class DownPanelUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject HeroUIPanel;
    [SerializeField] private GameObject EnemyUIPanel;
    [SerializeField] private GameObject MoveButton;
    private GameObject[] heroes;
    private GameObject[] enemies;


    public void Awake()
    {
        HeroUIPanel.SetActive(false);
        EnemyUIPanel.SetActive(false);

        //heroes = GameObject.FindGameObjectsWithTag("Hero");
        //foreach (GameObject hero in heroes)
        //{
        //    hero.GetComponent<Hero>().HeroSelected += NewSelection(Hero hero);

        //}
        //enemies = GameObject.FindGameObjectsWithTag("Monster");
        //foreach (GameObject enemy in enemies)
        //{
        //    enemy.GetComponent<Enemy>().EnemySelected += NewSelection(Enemy enemy);

        //}
    }

    private void Update()
    {
        if (RaidGlobals.GetSelectedObject() != null) 
        {
            if (RaidGlobals.SelectedObjectIsHero())
            {
                HeroUIPanel.SetActive(true);
                EnemyUIPanel.SetActive(false);
                HeroUIPanel?.GetComponent<HeroUIPanel>().UpdateEnergySlider();
                return;
            }

            if (RaidGlobals.SelectedObjectIsEnemy())
            {
                HeroUIPanel.SetActive(false);
                EnemyUIPanel.SetActive(true);
                return;
            }
        }    
    }

    private void NewSelection(Hero hero)
    {
        UpdatePanels();
    }

    //private void NewSelection(Enemy enemy)
    //{
    //    UpdatePanels();
    //}

    public void UpdatePanels()
    {
        //HeroUIPanel.SetActive(true);
        HeroUIPanel?.GetComponent<HeroUIPanel>().UpdatePanels();
        MoveButton?.GetComponent<MoveActionButton>().UpDateButtons();

        //EnemyUIPanel.GetComponent
    }
}
