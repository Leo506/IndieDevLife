using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Структура, представляющая награду
public struct Award
{
    public int numberMoney { get; private set; }
    public int numberDiskets { get; private set; }
    public Award(int money, int diskets)
    {
        this.numberMoney = money;
        this.numberDiskets = diskets;
    }
}


// Статический метод для получения награды для определённой работы и очков счёта на ней
public class AwardController : MonoBehaviour
{
    public static Award GetAward(int jobIndex, int score)
    {
        int numberOfMoney = 0;
        int numberOfDiskets = 0;

        // Определяем будет ли игра за дискеты
        if (Random.Range(0, 5) == 1)
        {
            numberOfDiskets = 50;
        }


        if (jobIndex != 2)
            numberOfMoney = 100 * jobIndex + score * 5;  // Подсчёт для всех подработок, кроме электрика
        else
            numberOfMoney = 100 * jobIndex + score * 2;  // Подсчёт для электрика

        return new Award(numberOfMoney, numberOfDiskets);
        
    }
}
