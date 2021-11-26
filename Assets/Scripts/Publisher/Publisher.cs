using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Publisher
{
    static int priceToPublish = 100;  // Цена издания игры
    static int chanceToHit = 0;       // Шанс на издание хита

    public static bool wasHit = false;

    public static int GetPriceToPublish()
    {
        return priceToPublish;
    }

    public static void SetChance(int creativityLvl, int numberOfGames)
    {
        if (numberOfGames > 0 && numberOfGames <= 16) {
            chanceToHit = (int)(Math.Pow(numberOfGames, 0.5) + creativityLvl + Boosts.GetTalantEffect() + Curses.GetCursesEffect());
        }

        if (Boosts.IsPlayerOnCreativity())
        {
            chanceToHit += 10;
        }
    }

    public static void SetPrice()
    {
        priceToPublish = (int)(Math.Pow(chanceToHit, 2) + 500);
    }

    public static int GetChanceToHit()
    {
        return chanceToHit;
    }

    public static void ResetData() {
        priceToPublish = 100;
        chanceToHit = 0;
    }
}
