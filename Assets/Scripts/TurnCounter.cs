using TMPro;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TurnCounterText;
    int i = 0;

    private void OnEnable()
    {

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

}
