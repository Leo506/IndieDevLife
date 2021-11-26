using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchieveItem
{
    public int Price { get; private set; }

    public TypeOfValute TypeOfPrice { get; private set; }

    public bool priceIsGotten = false;

    Func<float> lambda;

    public EventTypes myEventType { get; private set; }

    public AchieveItem(Func<float> f, int price, TypeOfValute type, EventTypes eventType) {
        lambda = f;
        Price = price;
        TypeOfPrice = type;
        myEventType = eventType;
    }

    public float GetCurrentProgress() {
        return lambda();
    }

    public void ClaimPrice()
    {

    }
}
