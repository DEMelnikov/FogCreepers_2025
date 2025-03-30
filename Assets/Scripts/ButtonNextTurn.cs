using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextTurn : MonoBehaviour
{
    [SerializeField] private bool IsPause = true;
    public delegate void OnNextTurn();
    public static event OnNextTurn onNextTurn;
    

    //onNextTurn 


    public void NextTurn()
    {
        onNextTurn?.Invoke();
        //Debug.LogFormat("pressed");
    }
   

    private void test1()
    {
        Debug.LogFormat("pressed - test");
    }

    public void SwitchPause()
    {
        if (IsPause) 
        { 
            IsPause = false;
            this.gameObject.GetComponent<Image>().color = Color.green;
        } 
        else 
        { 
            IsPause = true;
            this.gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    public bool GetIsPause()
    {
        return IsPause;
    }


}
