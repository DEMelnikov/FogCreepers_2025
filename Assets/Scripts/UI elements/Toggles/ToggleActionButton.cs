using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActionButton : MonoBehaviour
{
    [SerializeField] private GameObject ControlledButton;

    //private Toggle m_Toggle;//Get Toggle component
   //    private GameObject m_Toggle;



    public void ToggleValueChanged()
    {
        GameObject attached = gameObject;
        bool isOn = attached.GetComponent<Toggle>().isOn;

        if (isOn)
        {
            ControlledButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            ControlledButton.GetComponent<Button>().interactable = false;
        }
    }
}
