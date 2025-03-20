using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    // ButtonNextTurn testqq = new ButtonNextTurn();
    [SerializeField]
    private GameObject buttonqq;

    private void OnEnable()
    {

        //buttonqq.GetComponent<ButtonNextTurn>().
        ButtonNextTurn.onNextTurn += tempqwqq;

        //buttonqq.

        //ButtonNextTurn.onNextTurn +=
    }

    private void tempqwqq()
    {
        Debug.Log("pressed");
    }

}
