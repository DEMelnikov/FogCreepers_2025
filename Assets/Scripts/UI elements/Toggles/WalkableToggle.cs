using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WalkableToggle : MonoBehaviour
{
    [SerializeField] private GameObject avatarGameObject;
    private GameObject targetGameObject;

    private void OnEnable()
    {
        UpdateToggle(); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateToggle()
    {
        targetGameObject = avatarGameObject.GetComponent<AvatarImage>().GetSelectedGameObject();



        if (targetGameObject != null && targetGameObject.tag == "Hero")
        {
            Debug.Log("qqq" + targetGameObject.GetComponent<HeroOrdersStatus>().GetWalkAble());
            if (targetGameObject.GetComponent<HeroOrdersStatus>().GetWalkAble())
            {
                this.GetComponentInParent<Toggle>().isOn = true;
            }
            else { this.GetComponentInParent<Toggle>().isOn = false; }
        }
    }



}
