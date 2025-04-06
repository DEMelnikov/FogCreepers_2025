using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] int MapSize = 400;
    [SerializeField] private TileBase tileToSet;
    [SerializeField] private Tilemap backgroundTilemap;

    private int RowToCreate=0;


    //[SerializeField]
    //public int RunesQuantity = 3;
    //public GameObject Runeprefub;
    //public float RunePointBorderIndent = 30;


    //private float max_width;
    //private float max_height;
    //private 


    void Start()
    {
        //for (int i = 0; i < MapSize; i++) { MakeARows(); }

    }

    private void Awake()
    {
        //for (int i = 0; i < MapSize; i++) { MakeARows(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeARows()
    {
        RowToCreate++;

        for (int x = 0 - RowToCreate; x < RowToCreate; x++)
        {
            for (int y = 0 - RowToCreate; y < RowToCreate; y++)
                backgroundTilemap.SetTile(new Vector3Int(x, y, 0), tileToSet);
        }


    }
}
