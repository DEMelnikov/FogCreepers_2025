using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleActionButton : MonoBehaviour
{
   // [SerializeField] private GameObject ControlledButton;

    public void OnClick()
    {


        if (this.GetComponent<Toggle>().isOn)
        {
            Debug.Log("allow on " + RaidGlobals.GetSelectedObject().tag);
            if (RaidGlobals.GetSelectedObject() !=null && RaidGlobals.GetSelectedObject().tag== "Hero")
            {
                RaidGlobals.GetSelectedObject().GetComponent<HeroStatController>().SetMoveAllowed(true);
                //this.gameObject.GetComponentInParent<HeroUIPanel>().UpdatePanels();
            }
        }
        else
        {
            if (RaidGlobals.GetSelectedObject() != null && RaidGlobals.GetSelectedObject().tag == "Hero")
            {
                RaidGlobals.GetSelectedObject().GetComponent<HeroStatController>().SetMoveAllowed(false);
            }
        }
        this.gameObject.GetComponentInParent<DownPanelUIHandler>().UpdatePanels();
    }


}
