using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalButton : MonoBehaviour
{
    Button thisButton;

    private void Start() {
        thisButton = GetComponent<Button>();
    }

    public void OnButtonDown() {
        if (SurvivalGameController.instance.GetScore() >= 100) {
            SurvivalGameController.instance.AddScore(-100);
        } 
        SurvivalGameController.instance.CreateSurviver(this.gameObject.transform, thisButton);
    }
}
