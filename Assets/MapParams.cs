using UnityEngine;

public class MapParams : MonoBehaviour
{

    public int map_width = 400;
    public int map_height = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetWidth()
    {
        return map_width;
    }

    public float GetHeight()
    {
        return map_height;
    }
}
