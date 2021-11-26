using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateGameUtils
{
    // Обновление времени, требуемого для создания игры
    public static void UpdateTimeToCreateGame() {
        float time = CreatingGameInfo.TimeToCreateGame * 2;
        time = Mathf.Clamp(time, 100, 36000);

        CreatingGameInfo.TimeToCreateGame = time;
    }

    public static void UpdatePriceToSkip()
    {
        int price = (int)(CreatingGameInfo.TimeToCreateGame / 100 * GamesArchive.GetGames().Count);
        price = Mathf.Clamp(price, 0, 384);
        CreatingGameInfo.PriceToSkip = price;
    }


    // Обновление шанса кранча
    public static void UpdateChanceToCrunch() {
        int chance = 15 - SkillsLvl.possionLvl;
        CreatingGameInfo.ChanceToCrunch = chance;
    }
}
