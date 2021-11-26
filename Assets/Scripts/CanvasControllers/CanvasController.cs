using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    protected Canvas thisCanvas;
    [SerializeField] PanelAnim _anim;

    public void EnableThisCanvas()
    {
        if (!UIController.playerInUI)
        {
            thisCanvas.enabled = true;
            UIController.playerInUI = true;

            if (_anim != null)
                _anim.StartAnim();

            FirstNotify();
        }
    }

    public void DisableThisCanvas()
    {
        thisCanvas.enabled = false;
        UIController.playerInUI = false;
        SecondNotify();
    }

    virtual protected void FirstNotify() { }
    virtual protected void SecondNotify() { }
}
