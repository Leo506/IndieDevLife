using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static bool playerInUI = false;

    // Включение канваса, если другой канвас не включен
    public void EnableUI() {
        
        if (!playerInUI) {
            GetComponent<Canvas>().enabled = true;
            playerInUI = true;        
            Events.instance.Notify(EventTypes.CANVAS_ENABLE);
        }
    }


    public void DisableUI() {
        GetComponent<Canvas>().enabled = false;
        playerInUI = false;
        Events.instance.Notify(EventTypes.CANVAS_DISABLE);
    }

    
    public static bool IsPlayerInUI() {
        return playerInUI;
    }


    public static void ResetData()
    {
        playerInUI = false;
    }
}
