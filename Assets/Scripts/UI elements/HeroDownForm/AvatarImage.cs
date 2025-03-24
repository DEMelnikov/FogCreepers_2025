using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AvatarImage : MonoBehaviour
{

    private void OnEnable()
    {
        //ButtonNextTurn.onNextTurn += SmthSelected;
        Hero.heroSelected += SmthSelected;
    }

    private void SmthSelected(GameObject heroObject)
    {
        Debug.Log("Try to avatear " + heroObject.GetComponent<Hero>().GetAvatarSprite());
        Debug.Log(heroObject.GetComponent<Hero>().GetAvatarSprite());
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>(heroObject.GetComponent<Hero>().GetAvatarSprite());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
