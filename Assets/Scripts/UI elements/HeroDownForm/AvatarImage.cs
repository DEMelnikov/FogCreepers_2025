using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvatarImage : MonoBehaviour
{
    //[SerializeField] private GameObject selectedObject = null;
    private GameObject[] heroes ;
    private GameObject[] enemies;

    private void Awake()
    {
        heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes) {
            hero.GetComponent<Hero>().HeroSelected += SelectionIsHero;
        }

        enemies = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().EnemySelected += SelectionIsMonster;//.HeroSelected += SelectionIsHero;
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
             hero.GetHeroStats().GetHeroName());
    }

    private void SelectionIsMonster(Enemy enemy)
    {
        //Debug.Log("U are the champion!" + hero.GetAvatarSprite());
        //this.GetComponent<Image>().sprite = Resources.Load<Sprite>(hero.GetAvatarSprite());

        if (enemy.GetAvatarSprite() != null)
        {
            //AvatarImage.spr
            this.transform.Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>(enemy.GetAvatarSprite());
        }

        this.transform.Find("AvatarName").gameObject.GetComponent<TMP_Text>().SetText(
             enemy.GetMonsterName());
    }
}
