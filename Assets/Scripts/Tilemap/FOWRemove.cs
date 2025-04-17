using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FOWRemove : MonoBehaviour
{
    private Tilemap tilemap;

    [SerializeField] private float FoWRemoveTimer;

    //[SerializeField] private TileBase tileToSet;
    //[SerializeField] private TileBase tileToSet2;
    //private Camera mainCamera;
    [SerializeField]private int FOWClearRadius;
    private Countdown FoWRemoveCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        FoWRemoveCounter = new Countdown(FoWRemoveTimer,false);
        ClearFOW();

        //mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            //Vector3 ClickWorldPosition =  mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Vector3Int ClickCellPosition = tilemap.WorldToCell(ClickWorldPosition);
            //Debug.Log("tile Selected position" + ClickCellPosition);

        }

        if (FoWRemoveCounter.UpdateCountdown())
        {
            ClearFOW();
        }
    }

    public void ClearFOW()
    {
        FOWClearRadius++;

        for (int x = 0 - FOWClearRadius; x < FOWClearRadius; x++)
        {
            for (int y = 0 - FOWClearRadius; y < FOWClearRadius; y++)
                tilemap.SetTile(new Vector3Int(x, y, 0), null);
        }
    }
}
