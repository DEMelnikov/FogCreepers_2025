using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CamMouseController : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePosition;
    [SerializeField] private bool block = false;

    public LayerMask layerMask;
    public GraphicRaycaster graphicRaycaster; //from UI canvas
    public EventSystem eventSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            if (hit)
            {
                Debug.Log("Hit " + hit.collider.gameObject.name);
                block = true;
            }

            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerEventData, results);

            if (results.Count > 0)
            {
                block = true;
            }
        }

        Vector3 movement = Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            movement = cam.ScreenToWorldPoint(Input.mousePosition) - mousePosition;
        }

        if (!block)
        {
            cam.transform.position -= movement;
        }

        if (!Input.GetMouseButton(0))
        {
            block = false;
        }
    }

    private void OnMouseUp()
    {
        block = false;
    }

    //private void HandleLeftButtonMoving()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);


    //    }

    //    Vector3 movement = Vector3.zero;

    //    if (Input.GetMouseButton(0))
    //    {
    //        movement = cam.ScreenToWorldPoint(Input.mousePosition) - mousePosition;
    //    }

    //    cam.transform.position -= movement;

    //}
}

