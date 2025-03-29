using System;
using UnityEngine;

public class HeroUIPanel : MonoBehaviour
{
    [SerializeField] private Hero SelectedHero;

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
        }
    }
}
