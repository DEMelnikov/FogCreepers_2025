using UnityEditor.Build;
using UnityEngine;

public class Countdown
{
    private bool stopAfterTrigger;
    private float timeLimit;
    private bool triggerSent;
    private float countdown;// { set=> stopAfterTrigger = value; }

    public Countdown(float timeLimit, bool stopAfterTrigger)
    {
        if (timeLimit < 0) { timeLimit = 0; }
        this.countdown = timeLimit;
        this.timeLimit = timeLimit;
        this.stopAfterTrigger = stopAfterTrigger;
        this.triggerSent = false;
    }

    //public float countdown { get => countdown; set => countdown = value; }

    public bool UpdateCountdown()
    {
        //bool isTrigger = false;

        if (!IsPause.GetPauseState())
        {
            if (countdown >= 0) 
            { 
                countdown -= Time.deltaTime;
                return false;
            } 
            else 
            {
                bool message = false;

                if (triggerSent) { message = false; } else { triggerSent = true; message = true; }
                if (!stopAfterTrigger) { countdown = timeLimit; triggerSent = false; }

                return message; 
            }
        }

        return false;
    }

    public void StopCounterAfterTrigger()
    {
        stopAfterTrigger = false;
    }

    public float GetTimeLeft()
    {
        return countdown/timeLimit;
    }

}
