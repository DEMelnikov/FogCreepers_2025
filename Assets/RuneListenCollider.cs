using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RuneListenCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collision {other.name}");
        
        Component prentObj = transform.root;

       // prentObj.GetComponent<HeroMage>().SetStep(0);
        prentObj.GetComponent<HeroMage>().RuneKnownSwitch(true);
        prentObj.GetComponent<HeroMage>().SetAction(HeroActivities.idle);
        prentObj.GetComponent<HeroMage>().SetKnownRune(other.gameObject);
        //prentObj.GetComponent<HeroMage>().Set

        other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
