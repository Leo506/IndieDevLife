using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameCreator : MonoBehaviour
{
    private static DateTime createGameEndTime;  // Переменная для сохранения времени, когда должна будет создаться игра
    public static DateTime CreateGameEndTime
    {
        get { return createGameEndTime; }
        set { createGameEndTime = value; }
    }

    public static GameCreator instance;
    
    private void Awake()
    {
        var creators = FindObjectsOfType<GameCreator>();
        if (creators.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        // Если состояние игры находится еще в GameIsCreating, но время на создание игры вышло
        if (CreatingGameInfo.gameState == GameState.GameIsCreating && DateTime.Now >= createGameEndTime)
        {
            FinishCreateGame();
        }

        // Если состояние игры находится еще в GameIsCreating, но время на создание игры еще не вышло
        else if (CreatingGameInfo.gameState == GameState.GameIsCreating && DateTime.Now < createGameEndTime)
        {
            StartCoroutine(Creating());
        }
    }


    public void StartCreateGame(float value)
    {
        createGameEndTime = DateTime.Now.AddSeconds(value / 10);
        StartCoroutine(Creating());
    }

    public float GetCreatingProgress()
    {
        return (float)(createGameEndTime - DateTime.Now).TotalSeconds * 10;
    }

    public void OnCrunch()
    {
        createGameEndTime = createGameEndTime.AddSeconds(-1);
    }

    void FinishCreateGame()
    {
        CreatingGameInfo.gameState = GameState.GameCreated;
        Events.instance.Notify(EventTypes.END_CREATING);
    }

    public void SkipTime()
    {
        createGameEndTime = DateTime.Now;
    }

    IEnumerator Creating()
    {

        yield return new WaitUntil(() => DateTime.Now >= createGameEndTime);  // Ждём до окончания создания игры

        FinishCreateGame();
        
    }
}
