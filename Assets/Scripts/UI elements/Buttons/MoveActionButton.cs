using UnityEngine;
using UnityEngine.UI;

public class MoveActionButton : MonoBehaviour
{
    public void UpDateButtons()
    {
        if (RaidGlobals.GetSelectedObject())
        {
            Hero hero = RaidGlobals.GetSelectedObject().GetComponent<Hero>();

            if (hero != null && hero.tag == "Hero")
            {
                if (hero.GetHeroStats().GetMoveAllowed())
                {
                    this.gameObject.GetComponentInChildren<Button>().interactable = true;
                    this.gameObject.GetComponentInChildren<Toggle>().isOn = true;
                }
                else
                {
                    this.gameObject.GetComponentInChildren<Button>().interactable = false;
                    this.gameObject.GetComponentInChildren<Toggle>().isOn = false;
                }
            }
        }

    }

}
