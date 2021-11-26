using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    // Изображения состояний голода и сна
    [SerializeField] Sprite[] _hungryStatus, _sleepStatus;

    // Изменяемые изображения
    [SerializeField] Image[] hungryImage, sleepImage; 
    [SerializeField] Image _night;

    public float hungrySpeed;
    public float sleepSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DecreaseHungry");
        StartCoroutine("DecreaseSleep");
    }


    // Изменение величины голода
    IEnumerator DecreaseHungry()
    {
        while (true)
        {
            if (Boosts.IsPlayerOnFood())
            {
                hungrySpeed = 0;
            } else
            {
                hungrySpeed = 0.9f - SkillsLvl.stomachLvl * 0.045f;
            }
            Hungry.hungry -= hungrySpeed;
            Hungry.hungry = Mathf.Clamp(Hungry.hungry, 0, 100);
            if (Hungry.hungry >= 70)  // Если значение голода больше 70
            {
                hungryImage[0].sprite = _hungryStatus[0];  // Устанавливаем соответствующее изображение
                hungryImage[1].sprite = _hungryStatus[0];  // Устанавливаем соответствующее изображение
            }

            if (Hungry.hungry >= 40 && Hungry.hungry < 70)  // Если значение голода между 40 и 70
            {
                hungryImage[0].sprite = _hungryStatus[1];  // Устанавливаем соответствующие изображения
                hungryImage[1].sprite = _hungryStatus[1];  // Устанавливаем соответствующие изображения
            }

            if (Hungry.hungry < 40)  // Если значение меньше 40
            {
                hungryImage[0].sprite = _hungryStatus[2];  // Устанавливаем соответсятвующие изображения
                hungryImage[1].sprite = _hungryStatus[2];  // Устанавливаем соответсятвующие изображения
            }

            if (Hungry.hungry >= 40 && (Hungry.hungry - hungrySpeed) <= 40)
            {
                Events.instance.Notify(EventTypes.HUNGRY);
            }

            yield return new WaitForSeconds(1);
        }
    }


    // Уменьшение сонливости
    IEnumerator DecreaseSleep()
    {
        while (true)
        {
            if (Boosts.IsPlayerOnEnergy())
            {
                sleepSpeed = 0;
            } else
            {
                sleepSpeed = 0.6f - SkillsLvl.staminaLvl * 0.045f;
            }

            Sleep.ChangeSleepValue(-sleepSpeed);
            if (Sleep.GetSleepValue() >= 70)  // Если значение сна больше 70
            {
                sleepImage[0].sprite = _sleepStatus[0];  // Устанавливаем соответствующее изображение
                sleepImage[1].sprite = _sleepStatus[0];  // Устанавливаем соответствующее изображение
            }

            if (Sleep.GetSleepValue() >= 40 && Sleep.GetSleepValue() < 70)  // Если значение сна между 40 и 70
            {
                sleepImage[0].sprite = _sleepStatus[1];  // Устанавливаем соответствующие изображения
                sleepImage[1].sprite = _sleepStatus[1];  // Устанавливаем соответствующие изображения
            }

            if (Sleep.GetSleepValue() < 40)  // Если значение меньше 40
            {
                sleepImage[0].sprite = _sleepStatus[2];  // Устанавливаем соответсятвующие изображения
                sleepImage[1].sprite = _sleepStatus[2];  // Устанавливаем соответсятвующие изображения
            }

            if (Sleep.GetSleepValue() >= 40 && (Sleep.GetSleepValue() - sleepSpeed) <= 40)
            {
                Events.instance.Notify(EventTypes.SLEEPY);
            }

            yield return new WaitForSeconds(1);
        }
    }
}
