using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerClass : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider _progressSlider;  // Слайдер прогресса
    public float maxValue;  // Максимальное значение для слайдера
    public float valuePerClick;  // Сколько прибавляется за клик
 
    Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        _progressSlider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !ElectricGameController.instance.gameOver) {
            _progressSlider.value += valuePerClick;
            Events.instance.Notify(EventTypes.NORMAL_CLICK);

            // Если прогресс полный
            if (_progressSlider.value >= _progressSlider.maxValue) {
                SpawnDevice.instance.Spawn();
                _progressSlider.value = 0;
                ElectricGameController.instance.UpdateScoreText();
            }
        }
    }
}
