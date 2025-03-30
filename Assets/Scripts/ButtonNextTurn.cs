using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextTurn : MonoBehaviour
{
    [SerializeField] private bool IsInPause = true;
    public delegate void OnNextTurn();
    public static event OnNextTurn onNextTurn;
    

    //onNextTurn 


    public void NextTurn()
    {
        onNextTurn?.Invoke();
    }
   
    public void SwitchPause()
    {
        if (IsInPause) 
        { 
            IsInPause = false;
            IsPause.SetPause(IsInPause);
            this.gameObject.GetComponent<Image>().color = Color.green;
        } 
        else 
        { 
            IsInPause = true;
            IsPause.SetPause(IsInPause);
            this.gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    public bool GetIsPause()
    {
        return IsInPause;
    }


}
