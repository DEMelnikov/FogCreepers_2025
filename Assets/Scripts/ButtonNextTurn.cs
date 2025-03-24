using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextTurn : MonoBehaviour
{
    public delegate void OnNextTurn();
    public static event  OnNextTurn onNextTurn;

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


}
