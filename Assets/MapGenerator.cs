using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField]
    public int RunesQuantity = 3;
    public GameObject Runeprefub;
    public float RunePointBorderIndent = 30;


    //private float max_width;
    //private float max_height;
    //private 


    void Start()
    {
        MapGlobalActions Map = new MapGlobalActions(400, 200, 50);

        //GameObject obj = GameObject.Find("background");
        // max_width = obj.GetComponent<MapParams>().GetWidth();
       //  max_height = obj.GetComponent<MapParams>().GetHeight();        


        for (int i = 0; i<RunesQuantity; i++)
        {
            Instantiate(Runeprefub, Map.GetRandomPointWithIndent(true), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
