using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroUIController : MonoBehaviour
{
    private bool contoleable = true;

    public event Action<HeroUIController> OnHeroClicked, 
        OnHeroBeginDrag, OnHeroDroppedOn, OnHeroEndDrag;
    public void OnHeroPoinyClick()
    {
        Debug.Log("SelectedHero" + this.gameObject.tag);
    }

   // public void OnHeroClicked()
    //{
    //    if (!contoleable) { return; }
    //    OnHeroClicked?.Invoke(this);
   // }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
          if (pointerData.button == PointerEventData.InputButton.Right) 
            { Debug.Log("SelectedHero Right button" + this.gameObject.tag); }
            else
            { Debug.Log("SelectedHero Left button" + this.gameObject.tag); }
    }
}
