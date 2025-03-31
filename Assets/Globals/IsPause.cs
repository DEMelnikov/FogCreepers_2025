using UnityEngine;

public static class IsPause

{
    private static bool IsPaused = true;

    public static void SetPause(bool isPause ) {  IsPaused = isPause; }
    public static bool GetPauseState() { return IsPaused; }

}
