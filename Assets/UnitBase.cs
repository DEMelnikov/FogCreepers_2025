using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitBase : MonoBehaviour
{

    [SerializeField]
    
    public float DeafaultSpeed = 1f;
    public float RadiusRandomSearch = 30f;

    public HeroActivities ActiveAction = HeroActivities.idle;
    protected Vector2 TargetPoint;
    protected float stopRadius;
    protected int checkCloseToBGBorderforRandom = 4;
    protected bool exporeLeftDirection = true, exporeUpDirection = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetTargetPoint(new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected Vector2 GetTaregetPointExporeMode()
    {
        int deltaDown = 1, deltaUp = 1, deltaleft = 1, deltaRight = 1;

        GameObject obj = GameObject.Find("background");
        float max_width  = obj.GetComponent<MapParams>().GetWidth();
        float max_height = obj.GetComponent<MapParams>().GetHeight();

        if (transform.position.y - RadiusRandomSearch <= max_height / 2 * -1 && !exporeUpDirection) exporeUpDirection = true;
        if (transform.position.y + RadiusRandomSearch >= max_height / 2 && exporeUpDirection) exporeUpDirection = false;

        if (transform.position.x - RadiusRandomSearch <=  max_width / 2 * -1 && exporeLeftDirection) exporeLeftDirection = false;
        if (transform.position.x + RadiusRandomSearch >=  max_width / 2 && !exporeLeftDirection) exporeLeftDirection = true;

        if (exporeUpDirection)   deltaDown  = 0; else deltaUp   = 0;
        if (exporeLeftDirection) deltaRight = 0; else deltaleft = 0;

        Vector2 targetPoint = new Vector2(
           Random.Range(transform.position.x - RadiusRandomSearch * deltaleft, (transform.position.x + RadiusRandomSearch * deltaRight)),
           Random.Range(transform.position.y - RadiusRandomSearch * deltaDown, transform.position.y + RadiusRandomSearch * deltaUp));

        //Debug.Log ($"Got new point in ExporeMode {targetPoint.x} {targetPoint.y}");
        return targetPoint;
    }

    protected bool CheckTargersPointBordersOut(Vector2 TargetPoint)
    {
        bool checkRessult = true;

        GameObject obj = GameObject.Find("background");
        float max_width = obj.GetComponent<MapParams>().GetWidth();
        float max_height = obj.GetComponent<MapParams>().GetHeight();

        if (TargetPoint.x <= max_width / 2 * -1 || TargetPoint.x >= max_width / 2) checkRessult = false;
        if (TargetPoint.y <= max_height / 2 * -1 || TargetPoint.y >= max_height / 2) checkRessult = false;

        Debug.Log($"результат проверки на адекватность генерации точки - {checkRessult}");
        return checkRessult;
    }

    protected Vector2 GetRandomMapPoint()
    {
        Vector2 targetPoint = new Vector2(-2000, -2000); //плохая логика - переделать

        do
        {
            var tp = Random.insideUnitCircle.normalized * RadiusRandomSearch;
            targetPoint = new Vector2(tp.x, tp.y);

        } while (!CheckTargersPointBordersOut(targetPoint));

        


        print($"Got new point {targetPoint.x} {targetPoint.y}");

        return targetPoint;
    }
    protected  Vector2 GetRandomMapPoint2()
    {

        //GameObject obj = GameObject.FindGameObjectWithTag("MapBackground");
        int hdeltaDown=1, hdeltaUp = 1, wdeltaleft=1, wdeltaRight = 1;
        //float wdelta;

        //Find the GameObject
        GameObject obj = GameObject.Find("background");
        float max_width = obj.GetComponent<MapParams>().GetWidth();
        float max_height = obj.GetComponent<MapParams>().GetHeight();

        if (transform.position.y <= max_height /((1-(100/checkCloseToBGBorderforRandom)) * -1)) hdeltaDown = 0;
        if (transform.position.y >= max_height / checkCloseToBGBorderforRandom) hdeltaUp = 0;
        if (transform.position.x <=  max_width / checkCloseToBGBorderforRandom*-1) wdeltaleft = 0;
        if (transform.position.x >=  max_width / checkCloseToBGBorderforRandom) wdeltaRight = 0;

        //if (transform.position.x <= max_width / checkCloseToBGBorderforRandom * -1) { wdelta = 1; } else { wdelta = -1; }

        //Vector2 targetPoint = new Vector2(Random.Range(transform.position.x, (transform.position.x+ RadiusRandomSearch)*wdelta), (transform.position.y + RadiusRandomSearch) * hdelta);


        Vector2 targetPoint = new Vector2(
            Random.Range(transform.position.x - RadiusRandomSearch* wdeltaleft, (transform.position.x + RadiusRandomSearch* wdeltaRight) ),
            Random.Range(transform.position.y - RadiusRandomSearch* hdeltaDown,  transform.position.y + RadiusRandomSearch* hdeltaUp) );



        //print($"GameObj found  +  {obj.GetComponent<MapParams>().GetHeight()}");

        //Vector2 targetPoint = new Vector2(obj.GetComponent<MapParams>().GetHeight, 1f);


        //transform.position = Random.insideUnitCircle * RadiusRandomSearch;


        //Vector2 targetPoint = new Vector2(1f, 1f);
        print($"Got new point {targetPoint.x} {targetPoint.y}");
        return targetPoint;
    }

    protected void MoveToTargetPoint()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _endPos, Time.deltaTime * _velocity);
    }


    protected void GetNewAction()
    {
        

    }

    public void SetAction(HeroActivities Action)
    {
        ActiveAction = Action;
    }

    public void SetTargetPoint (Vector2 TP)
    {
        TargetPoint = TP;
    }
}
