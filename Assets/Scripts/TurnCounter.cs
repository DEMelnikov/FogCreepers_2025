using TMPro;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    //[SerializeField]
    private TMP_Text TurnCounterText;
    int i = 0;

    private void OnEnable()
    {

        TurnCounterText = GameObject.Find("TurnCounter").GetComponent<TMP_Text>();
        //ButtonNextTurn.onNextTurn += CounterUp;

    }

    private void Update()
    {
        if (!IsPause.GetPauseState())
        {
            TurnCounterText.SetText(TurnsCounter.GetTurnsCounter().ToString());
        }
            
    }

    private void CounterUp()
    {
        i++;

        
        TurnCounterText.SetText(i.ToString());
    }

    private void OnDisable()
    {
        //ButtonNextTurn.onNextTurn -= CounterUp;
    }

}
