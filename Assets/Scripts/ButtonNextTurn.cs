using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextTurn : MonoBehaviour
{
    [SerializeField] private float TurnSecondsLimit;
    [SerializeField] private GameObject toggleAutoPause;
    public delegate void OnNextTurn();
    public static event OnNextTurn onNextTurn;
    private float turnTimer=0;

    private void Awake()
    {
        turnTimer = TurnSecondsLimit;
        //toggleAutoPause = GetComponent
    }

    private void Update()
    {
        if (!IsPause.GetPauseState())
        {         
            if (turnTimer >= 0) { turnTimer -= Time.deltaTime; Debug.Log(turnTimer); } else { NextTurn(); }
        }
    }

    public void NextTurn()
    {
        TurnsCounter.NewTurn();
        turnTimer = TurnSecondsLimit;
        onNextTurn?.Invoke();
        if (!toggleAutoPause.GetComponent<Toggle>().isOn) { SwitchPause(); }
    }
   
    public void SwitchPause()
    {
        if (IsPause.GetPauseState()) 
        { 
            IsPause.SetPause(false);
            //IsPause.SetPause(IsInPause);
            this.gameObject.GetComponent<Image>().color = Color.green;
        } 
        else 
        { 
            //IsInPause = true;
            IsPause.SetPause(true);
            this.gameObject.GetComponent<Image>().color = Color.red;
        }
    }


}
