using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublisherCanvasController : CanvasController
{
    // Start is called before the first frame update
    void Start()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    protected override void FirstNotify()
    {
        Events.instance.Notify(EventTypes.CANVAS_ENABLE);
        Events.instance.Notify(EventTypes.ENTER);
    }

    protected override void SecondNotify()
    {
        Events.instance.Notify(EventTypes.CANVAS_DISABLE);
        Events.instance.Notify(EventTypes.EXIT);
    }

}
