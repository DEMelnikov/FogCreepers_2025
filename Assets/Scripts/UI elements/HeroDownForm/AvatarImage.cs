using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AvatarImage : MonoBehaviour
{
    [SerializeField] private GameObject waypoint;
    [SerializeField] private GameObject waypointPrefub;
    [SerializeField] private GameObject selectedObject = null;

    private void OnEnable()
    {
        //ButtonNextTurn.onNextTurn += SmthSelected;
        Hero.heroSelected += SmthSelected;
    }

    private void SmthSelected(GameObject heroObject)
    {
        Debug.Log("Try to avatear " + heroObject.GetComponent<Hero>().GetAvatarSprite());
        Debug.Log(heroObject.GetComponent<Hero>().GetAvatarSprite());

        if (heroObject != null) {
            SetSelectedObject(heroObject);

            if (heroObject.tag == "Hero")
            {
                this.GetComponent<Image>().sprite =
                    Resources.Load<Sprite>(heroObject.GetComponent<Hero>().GetAvatarSprite());
                this.transform.Find("AvatarName").gameObject.GetComponent<TMP_Text>().SetText(
                    heroObject.GetComponent<HeroStatController>().GetHeroName());

                Vector2 HeroWaypoint = heroObject.GetComponent<HeroStatController>().GetTargetWaypoint();

                if (HeroWaypoint == new Vector2(0, 0) && waypoint!=null) { Destroy(waypoint); }

                if (HeroWaypoint != new Vector2(0, 0))
                {
                    if (waypoint != null) { Destroy(waypoint); }

                    waypoint = Instantiate(waypointPrefub, HeroWaypoint, Quaternion.identity);
                }
            }


        }
    }

    public GameObject GetSelectedGameObject()
    {
        return selectedObject;
    }

    private void SetSelectedObject (GameObject selectedObject)
    {
        this.selectedObject = selectedObject;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
