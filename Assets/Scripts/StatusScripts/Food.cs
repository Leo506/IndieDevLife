using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Food
{
    // Количество продуктов в данный момент
    static Dictionary<string, int> foodList = new Dictionary<string, int>
    {
        {"Apple", 0 },
        {"Milk", 0 },
        {"Bread", 0 },
        {"Cheese", 0},
        {"Juice", 0},
        {"Egg", 0}
    };

    // Цена на каждый вид продуктов
    static Dictionary<string, int> foodPrice = new Dictionary<string, int> 
    {
        {"Apple", 30 },
        {"Milk", 30 },
        {"Bread", 30 },
        {"Cheese", 30},
        {"Juice", 30},
        {"Egg", 30}
    };

    // Количество очков сытости, которое восполняет каждый вид продуктов
    static Dictionary<string, float> fullnesOfFood = new Dictionary<string, float>
    {
        {"Apple", 15 },
        {"Milk", 15 },
        {"Bread", 15 },
        {"Cheese", 15},
        {"Juice", 15},
        {"Egg", 15}
    };

    // Добавление единицы продукта
    public static void AddFood(string foodName)
    {
        foodList[foodName] += 1;
    }

    // Поедание еды
    public static void EatFood(string foodName)
    {
        if (foodList[foodName] > 0) {
            foodList[foodName]--;
            Hungry.hungry += fullnesOfFood[foodName];
        }
    }

    public static int CountOfFood(string foodName)
    {
        return foodList[foodName];
    }

    public static int GetFoodPrice(string foodName)
    {
        return foodPrice[foodName];
    }


    public static void ResetData() {

        foodList = new Dictionary<string, int>
        {
            {"Apple", 0 },
            {"Milk", 0 },
            {"Bread", 0 },
            {"Cheese", 0},
            {"Juice", 0},
            {"Egg", 0}
        };

    }

    public static Dictionary<string, int> GetFoodList() {
        return foodList;
    }

    public static void SetFoodList(Dictionary<string, int> dict) {
        foodList = dict;
    }

}
