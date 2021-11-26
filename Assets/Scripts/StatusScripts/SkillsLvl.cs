using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillsLvl
{
    public static int creativityLvl = 0;
    public static int staminaLvl = 0;
    public static int stomachLvl = 0;
    public static int possionLvl = 0;

    public static void ResetData() {
        creativityLvl = 0;
        staminaLvl = 0;
        stomachLvl = 0;
        possionLvl = 0;

        UpgradeSkillsScript.instance.Start();
    }
}
