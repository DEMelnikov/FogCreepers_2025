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
        //buttonqq.GetComponent<ButtonNextTurn>().
        ButtonNextTurn.onNextTurn += CounterUp;

        //buttonqq.

        //ButtonNextTurn.onNextTurn +=
    }

    private void CounterUp()
    {
        i++;

        
        TurnCounterText.SetText(i.ToString());
    }

    private void OnDisable()
    {
        ButtonNextTurn.onNextTurn -= CounterUp;
    }

}
