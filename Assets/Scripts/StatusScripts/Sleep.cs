using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sleep
{
    static float sleep = 100;
    
    public static void ChangeSleepValue(float value)
    {
        sleep += value;
        sleep = Mathf.Clamp(sleep, 0, 100);
    }

    public static void SetSleepValue(float value) {
        sleep = value;
    }

    public static float GetSleepValue()
    {
        return sleep;
    }

    public static void ResetData() {
        sleep = 100;
    }
}
