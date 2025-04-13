using System.Collections.Generic;
using UnityEngine;

public class CollectionWithTag
{
    private List<GameObject> objects = new List<GameObject>();
    private string tag;
    private float radiusUpdate;

    public CollectionWithTag (string tag, float radiusUpdate )
    {
        this.tag = tag;
        this.radiusUpdate = radiusUpdate;
    }

    public void UpdateCollection( Transform position, float multiplier)
    {
        objects.Clear();
        var colliders = Physics2D.OverlapCircleAll(position.position, radiusUpdate * multiplier );
        foreach (var collider in colliders)
        {
            //Debug.Log($"{collider.gameObject.name} is nearby");
            if (collider.gameObject.tag == tag)
            {
                objects.Add(collider.gameObject);
            }
        }
    }

    public float Count()
    {
        return objects.Count;
    }

    public GameObject GetFirst() 
    {
        if ( objects.Count > 0 ) { return objects[0]; } 
        return null;
    }
}
