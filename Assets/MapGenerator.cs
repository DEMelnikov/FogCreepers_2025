using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField]
    public int RunesQuantity = 3;
    public GameObject Runeprefub;
    public float RunePointBorderIndent = 30;


    private float max_width;
    private float max_height;
    //private 


    void Start()
    {
        GameObject obj = GameObject.Find("background");
         max_width = obj.GetComponent<MapParams>().GetWidth();
         max_height = obj.GetComponent<MapParams>().GetHeight();        


        for (int i = 0; i<RunesQuantity; i++)
        {
            Instantiate(Runeprefub, GetRandomPoint(), Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 GetRandomPoint()
    {
        //Vector2 RandomPoint = new Vector2(0, 0);

        Vector2 RandomPoint = new Vector2(
            Random.Range(max_width/2*-1 + RunePointBorderIndent, max_width/2 - RunePointBorderIndent),
            Random.Range(max_height/2*-1 + RunePointBorderIndent , max_height/2- RunePointBorderIndent));

        print($"Random x {RandomPoint.x} and {RandomPoint.y}");

        return RandomPoint;
    }
}
