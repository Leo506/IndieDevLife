using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public int sec;  // Количество секунд для таймера
    [SerializeField] Slider _timerSlider;  // Слайдер - таймер
    [SerializeField] Text _timerText;  // Текст - таймер
    [SerializeField] AudioSource _audioSource;

    public bool gameOver { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Настраиваем таймер
        if (_timerSlider != null) {
            _timerSlider.maxValue = sec * 100;
            _timerSlider.value = _timerSlider.maxValue;
            StartCoroutine(StartSliderTimer());  // Запускаем корутину для обратного отсчёта таймера
        } else {
            StartCoroutine(StartTextSlider());
        }

        gameOver = false;
    }


    // Для таймера в виде слайдера
    IEnumerator StartSliderTimer() {
        for (int i = (int)_timerSlider.maxValue; i > 0; i--){
            _timerSlider.value--;
            yield return new WaitForSeconds(0.01f);
        }

        if (_audioSource != null)
            _audioSource.Stop();

        gameOver = true;

        Events.instance.Notify(EventTypes.JOB_FINISH);
        Time.timeScale = 0;
    }


    // Для таймера в виде текста
    IEnumerator StartTextSlider() {
        for (int i = sec; i >= 0; i--)
        {
            _timerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        if (_audioSource != null)
            _audioSource.Stop();

        gameOver = true;

        Events.instance.Notify(EventTypes.JOB_FINISH);
        Time.timeScale = 0;
    }
}
