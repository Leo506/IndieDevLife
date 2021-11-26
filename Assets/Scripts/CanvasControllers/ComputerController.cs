using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : CanvasController
{

    private void Start()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    override protected void FirstNotify()
    {
        Events.instance.Notify(EventTypes.SIT_DOWN);
    }

    protected override void SecondNotify()
    {
        Events.instance.Notify(EventTypes.STAND_UP);
    }



    // Включение канвасов через внутренние кнопки
    public void EnableInternalCanvas(Canvas can)
    {
        can.enabled = true;
        thisCanvas.enabled = false;
        Events.instance.Notify(EventTypes.CANVAS_ENABLE);
    }

    // Выключение канвасов
    public void DisableInternalCanvas(Canvas can)
    {
        can.enabled = false;
        thisCanvas.enabled = true;
        Events.instance.Notify(EventTypes.CANVAS_DISABLE);
    }
}
