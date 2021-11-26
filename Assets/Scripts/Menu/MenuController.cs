using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas _canvas, _dailyBonusCanvas;


    public void StartGame() {
        // Проверяем должен ли игрок получить награду
        // Если да, то включаем канвас с наградами
        // Если нет - загружаем игру

        if (DailyBonusController.instance.CheckTime()) {
            _canvas.enabled = false;
            _dailyBonusCanvas.enabled = true;
        } else {
            if (!Education.greetingsShown)
            {
                LoadSceneController.instance.LoadSceneByName("Introduction");
                Education.greetingsShown = true;
            }
            else
                LoadSceneController.instance.LoadSceneByName("LoadingScene");
        }
    }
}
