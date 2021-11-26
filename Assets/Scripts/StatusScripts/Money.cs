using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Money
{
    static int money = 2000;
    static int floppyDisks = 0;

    public static int GetMoney()
    {
        return money;
    }

    public static void ChangeMoney(int value)
    {
        if (-value <= money) money += value;
        Events.instance.Notify(EventTypes.MONEY_CHANGED);
    }

    public static void ChangeMoney(int value, bool hasCheck) {
        if (hasCheck) ChangeMoney(value);
        else money += value;
    }

    public static int GetFloppyDisks()
    {
        return floppyDisks;
    }

    public static void ChangeFloppyDisks(int value)
    {
        floppyDisks += value;
    }

    public static void ResetData() {
        money = 2000;
    }

    public static void SetMoney(int m, int fD) {
        money = m;
        floppyDisks = fD;
    }
}
