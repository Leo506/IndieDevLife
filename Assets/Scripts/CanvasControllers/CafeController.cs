using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeController : CanvasController
{
    // Start is called before the first frame update
    void Start()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    protected override void FirstNotify()
    {
        Events.instance.Notify(EventTypes.ENTER);
        Events.instance.Notify(EventTypes.CANVAS_ENABLE);
    }

    protected override void SecondNotify()
    {
        Events.instance.Notify(EventTypes.EXIT);
        Events.instance.Notify(EventTypes.CANVAS_DISABLE);
    }
}
