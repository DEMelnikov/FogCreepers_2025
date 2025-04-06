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
    private Countdown countdown;// = new Countdown


    private void Awake()
    {
        //turnTimer = TurnSecondsLimit;
        countdown = new Countdown(TurnSecondsLimit, false);

        //toggleAutoPause = GetComponent
    }

    private void Update()
    {
       if(countdown.UpdateCountdown())
       {
            NextTurn();
       }
        
        //CountDown();
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

    //private void CountDown()
    //{
    //    if (!IsPause.GetPauseState())
    //    {
    //        if (turnTimer >= 0) { turnTimer -= Time.deltaTime; } else { NextTurn(); }
    //    }
    //}
}
