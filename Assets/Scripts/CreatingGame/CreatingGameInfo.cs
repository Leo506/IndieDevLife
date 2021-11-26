using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameIsCreating,
    GameCreated,
    NoGame
}

public struct CreatingGameInfo
{
    public static float CompleteTime = 0;                  // Время, потраченное на создание игры
    public static float TimeToCreateGame = 100;            // Время, небходимое для создания новой игры
    public static int ChanceToCrunch = 15;                 // Шанс на кранч
    public static string GameName = "";                    // Название создаваемой игры
    public static GameState gameState = GameState.NoGame;  // Состояние создания игры
    public static int PriceToSkip = 0;                     // Цена пропуска времени создания игры

    public static void ResetData() {
        CompleteTime = 0;
        TimeToCreateGame = 100;
        ChanceToCrunch = 15;
        GameName = "";
        gameState = GameState.NoGame;
    }

}
