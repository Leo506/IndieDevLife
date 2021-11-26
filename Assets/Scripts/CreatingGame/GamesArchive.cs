using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamesArchive
{

    static List<CreatedGame> games = new List<CreatedGame>();
    
    public static void AddGame(string gameName)
    {
        games.Add(new CreatedGame(gameName, 0, false));
    }

    public static List<CreatedGame> GetGames()
    {
        return games;
    }

    public static List<CreatedGame> GetAvaliableToSellGames()
    {
        var returnGames = new List<CreatedGame>();

        for (int i = 0; i < games.Count; i++)
        {
            if (!games[i].isPublished)
            {
                returnGames.Add(games[i]);
            }
        }

        return returnGames;
    }

    public static void ChangeGameStatus(CreatedGame game, int money)
    {
        int index = games.IndexOf(game);
        games[index] = new CreatedGame(games[index].name, money, true);
    }

    public static List<int> GetRecivedMoney()
    {
        List<int> recievedMoney = new List<int>();

        foreach (var item in games)
        {
            recievedMoney.Add(item.receivedMoney);
        }

        return recievedMoney;
    }

    public static void ResetData() {
        games = new List<CreatedGame>();
    }

    public static List<bool> GetGamesStatus() {
        List<bool> gamesStatus = new List<bool>();

        foreach (var item in games)
        {
            gamesStatus.Add(item.isPublished);
        }

        return gamesStatus;
    }

    public static void SetGameArchive(List<CreatedGame> g) {
        games = g;
    }
}
