using System;
using UnityEngine;

public class AvatarImage : MonoBehaviour
{
    [SerializeField] private GameObject selectedObject = null;
    [SerializeField] private GameObject HeroUIpanel;
    private GameObject[] heroes ;

    private void Awake()
    {
        heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes) {
            hero.GetComponent<Hero>().HeroSelected += SelectionIsHero;
        }
    }

    private void SelectionIsHero(Hero hero)
    {
        Debug.Log("U are the champion!"+hero.name);
    }
}
