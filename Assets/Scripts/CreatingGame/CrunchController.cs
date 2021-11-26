using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrunchController : MonoBehaviour
{
    // Slider progressSlider;
    // CreateGameScript script;
    // string gameName;

    // public void StartCrunch(string gameName, Slider slider, CreateGameScript scr)
    // {
    //     this.gameName = gameName;
    //     this.script = scr;
    //     this.progressSlider = slider;
    //     this.progressSlider.maxValue *= 0.66f;
    //     StartCoroutine("Crunching");
    // }

    // public void StopCrunch() {
    //     StopCoroutine("Crunching");
    // }

    // private void Update()
    // {
    //     if (Input.anyKeyDown)
    //     {
    //         progressSlider.value += 5;
    //     }
    // }

    // IEnumerator Crunching()
    // {
    //     while (progressSlider.value != progressSlider.maxValue)
    //     {
    //         progressSlider.value++;
    //         yield return new WaitForSeconds(0.1f);
    //     }

    //     script.StartCoroutine("ShowAlert");
    //     GamesArchive.AddGame(gameName);
    //     Player.AddExp(40);
    //     CreatingGameInfo.TimeToCreateGame = 0;
    // }
}
