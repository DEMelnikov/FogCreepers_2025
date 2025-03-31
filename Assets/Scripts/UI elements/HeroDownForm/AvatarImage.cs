using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvatarImage : MonoBehaviour
{
    //[SerializeField] private GameObject selectedObject = null;
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
        Debug.Log("U are the champion!"+hero.GetAvatarSprite());
        //this.GetComponent<Image>().sprite = Resources.Load<Sprite>(hero.GetAvatarSprite());

        if (hero.GetAvatarSprite()!=null)
        {
            //AvatarImage.spr
            this.transform.Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>(hero.GetAvatarSprite());
        }

        this.transform.Find("AvatarName").gameObject.GetComponent<TMP_Text>().SetText(
             hero.GetComponent<HeroStatController>().GetHeroName());
    }
}
