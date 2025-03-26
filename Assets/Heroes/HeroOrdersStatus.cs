using UnityEngine;

public class HeroOrdersStatus : MonoBehaviour
{
    [SerializeField] private bool WalkAble = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetWalkAble() {  return WalkAble; }
    public void SetWalkAble(bool value) { WalkAble = value; }


}
