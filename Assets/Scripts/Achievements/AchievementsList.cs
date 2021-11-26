using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AchievementsList
{
    public static AchieveItem[] progress = {
        new AchieveItem(() => {if (GamesArchive.GetGames().Count >= 1) return 1; else return 0;}, 100, TypeOfValute.Money, EventTypes.GAME_CREATED),
        new AchieveItem(() => {if (GamesArchive.GetGamesStatus().Count != 0 && GamesArchive.GetGamesStatus().Contains(true)) return 1; else return 0;}, 200, TypeOfValute.Money, EventTypes.GAME_PUBLISHED),
        new AchieveItem(() => {if (Curses.GetCurseStatus(1) == Curses.CurseStatus.Complete) return 1; else return 0; }, 200, TypeOfValute.Money, EventTypes.CURSE_TOOK),
        new AchieveItem(() => {if (WorkController.NumberOfSideJob >= 5) return 1; else return 0; }, 300, TypeOfValute.Money, EventTypes.GO_TO_WORK),
        new AchieveItem(() => {if (Money.GetMoney() >= 10000)  return 1;  else return 0; }, 500, TypeOfValute.Money, EventTypes.MONEY_CHANGED),
        new AchieveItem(() => {if (Publisher.wasHit) return 1;  else return 0; }, 5000, TypeOfValute.Money, EventTypes.GAME_PUBLISHED)
    };

    public static void ResetData()
    {
        foreach (var item in progress)
        {
            item.priceIsGotten = false;
        }
    }
}
