using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField] Canvas _notifyCanvas;
    IEnumerator checkCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        checkCoroutine = CheckPlayerStatus();
        StartCoroutine(checkCoroutine);
    }

    // Вывод предупреждающего сообщения
    private void NotifyAboutDeath() {
        Debug.Log("NOTIFY!!!");
        StopCoroutine(checkCoroutine);
        Time.timeScale = 0;
        _notifyCanvas.enabled = true;
    }

    // Запуск таймера
    public void StartCountBeforeDeath() {
        Time.timeScale = 1;
        StartCoroutine(CountBeforeDeath());
    }


    IEnumerator CheckPlayerStatus() {
        
        // Цикл, в котором проверяется состояние игрока каждую секунду
        while (true)
        {
            // Если у игрока показатель (показатели) слишком малы, то вывовид предупреждающее сообщение
            if (Hungry.hungry <= 0 || Sleep.GetSleepValue() <=0) {
                NotifyAboutDeath();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    // Обратный отсчёт до смерти. Если по его окончанию состояние персонажа не улучшилось - смерть (game over)
    IEnumerator CountBeforeDeath() {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(1);
        }

        if (Hungry.hungry <= 0 || Sleep.GetSleepValue() <= 0) {
            Game.ResetGame();
            SceneManager.LoadScene("DeathScene");
        } else {
            checkCoroutine = CheckPlayerStatus();
            StartCoroutine(checkCoroutine);
        }
    }
}
