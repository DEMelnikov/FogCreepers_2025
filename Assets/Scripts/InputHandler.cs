using UnityEngine;
using static Hero;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject SelectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
           {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Debug.Log("hit " + mousePos2D.y);


            //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //if (hit.collider == null && SelectedObject.GetComponent<AvatarImage>().GetSelectedGameObject() != null)
            //{
            //    if (SelectedObject.GetComponent<AvatarImage>().GetSelectedGameObject().tag == "Hero")
            //    {
            //        SelectedObject.GetComponent<AvatarImage>().GetSelectedGameObject().
            //            GetComponent<HeroStatController>().SetTargerWaypoint(mousePos2D);
            //        Debug.Log("new waypoint set" + mousePos2D.y);
            //        SelectedObject.GetComponent<AvatarImage>().GetSelectedGameObject().
            //            GetComponent<Hero>().Hero_Selected();

            //        heroSelected?.Invoke(this.gameObject);
            //    }
            //}
        }
    }
    }
