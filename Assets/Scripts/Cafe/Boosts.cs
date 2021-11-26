using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Boosts
{
    static bool onEnergy = false;                                 // Булевая переменная, определяющая, 
                                                                  // находится ли игрок под действием енергетика
    public static DateTime startEnergyTime { get; private set; }  // Время начала действия енергетика

    static bool onFood = false;                                   // Булевая переменная, определяющая, 
                                                                  // находится ли игрок под действием коктейля сытости
    public static DateTime startFoodTime { get; private set; }    // Время начала действия коктейля сытости

    static bool onCreativity = false;                             // Булевая переменная, определяющая, 
                                                                  // находится ли игрок под действием коктейля креативности

    static bool onTalant = false;                                 // Булевая переменная, определяющая, 
                                                                  // находится ли игрок под действием коктейля таланта



    public static bool IsPlayerOnEnergy()
    {
        if (onEnergy)
        {
            if (DateTime.Now < startEnergyTime.AddMinutes(5))
            {
                return true;
            } else
            {
                onEnergy = false;
                return false;
            }
        }

        return false;
    }

    public static void BuyEnergyCocktail(int price)
    {
        onEnergy = true;
        startEnergyTime = DateTime.Now;
        Money.ChangeFloppyDisks(-price);
    }

    public static bool IsPlayerOnFood()
    {
        if (onFood)
        {
            if (DateTime.Now < startFoodTime.AddMinutes(5))
            {
                return true;
            }
            else
            {
                onFood = false;
                return false;
            }
        }

        return false;
    }

    public static void BuyFoodCocktail(int price)
    {
        onFood = true;
        startFoodTime = DateTime.Now;
        Money.ChangeFloppyDisks(-price);
    }

    public static bool IsPlayerOnCreativity()
    {
        return onCreativity;
    }

    public static void DisableCreativityEffect()
    {
        onCreativity = false;
    }

    public static void BuyCreativityCocktail(int price)
    {
        onCreativity = true;
        Money.ChangeFloppyDisks(-price);
    }

    public static bool IsPlayerOnTalant()
    {
        return onTalant;
    }

    public static void BuyTalantCocktail(int price)
    {
        onTalant = true;
        Money.ChangeFloppyDisks(-price);
    }

    public static int GetTalantEffect()
    {
        if (onTalant)
        {
            return 20;
        }

        return 0;
    }

    public static void SetUp(bool energy, bool food, bool creativity, bool talant, DateTime enTime, DateTime fTime)
    {
        onEnergy = energy;
        onFood = food;
        onCreativity = creativity;
        onTalant = talant;

        startEnergyTime = enTime;
        startFoodTime = fTime;
    }
}
