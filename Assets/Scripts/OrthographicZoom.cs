using UnityEngine;

public class OrthographicZoom : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float maxZoom =5;
    [SerializeField] private float minZoom =20;
    [SerializeField] private float sensitivity = 1;
    [SerializeField] private float speed =30;
    float targetZoom;

    void Start()
    {
        targetZoom = cam.orthographicSize;
    }
    void Update()
    {
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
}
