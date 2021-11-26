using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : CanvasController
{
    [SerializeField] FoodController _foodController;

    // Start is called before the first frame update
    void Start()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    protected override void FirstNotify()
    {
        Events.instance.Notify(EventTypes.FRIDGE_OPEN);
    }

    protected override void SecondNotify()
    {
        Events.instance.Notify(EventTypes.FRIDGE_CLOSE);
    }

    public void Eat(string foodName)
    {
        _foodController.EatFood(foodName);
        Events.instance.Notify(EventTypes.EAT);
    }
}
