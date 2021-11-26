using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DailyBonusController : MonoBehaviour
{
    public static DateTime timeOfLastBonus;       // Время получения последней ежедневной награды
    public static int bonusIndex = 0;             // Индекс последней полученной награды
    public static DailyBonusController instance;

    int[] daysBonus = {50, 150, 300, 450, 600, 750, 500};

    private void Awake() {
        instance = this;
    } 


    // Проверка на то, может ли игрок получить сейчас награду
    public bool CheckTime() {
        return DateTime.Now >= timeOfLastBonus.AddDays(1);
    }


    // Получение награды
    public void GetBonus() {
        if (bonusIndex != 6) {
            Money.ChangeMoney(daysBonus[bonusIndex]);
            bonusIndex++;
        } else {
            Money.ChangeFloppyDisks(daysBonus[bonusIndex]);
            bonusIndex = 0;
        }

        timeOfLastBonus = DateTime.Now;

        if (!Education.greetingsShown)
        {
            LoadSceneController.instance.LoadSceneByName("Introduction");
            Education.greetingsShown = true;
        }
        else
            LoadSceneController.instance.LoadSceneByName("LoadingScene");
    }
}
