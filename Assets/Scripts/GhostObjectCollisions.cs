using UnityEngine;

public class GhostObjectCollisions : MonoBehaviour
{
    private GameObject collisionObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collisionObject != null) 
        {
            Debug.Log("Got Collision " + collision.gameObject.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collisionObject != null)
        {
            Debug.Log("Got Collision " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Got Collision " + collision.gameObject.name);
    }

}
