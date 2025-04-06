using System;
using UnityEngine;

public static class TurnsCounter
{
    //private static int turnsCounter;

    public static Action onNewTurn;

    private static int turnsCounter;

    public static int GetTurnsCounter()
    {
        return turnsCounter;
    }

    public static void NewTurn()
    {
        turnsCounter++;
        onNewTurn?.Invoke();
    }
}
