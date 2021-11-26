using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathSceneController : MonoBehaviour
{
    [SerializeField] Image _deathText;
    [SerializeField] Button _playAgainButton, _exitButton;

    private void Start() {
        StartCoroutine(AppearText());
    }



    IEnumerator AppearText() {
        for (int i = 0; i <= 25; i++)
        {
            _deathText.color = new Color(1, 1, 1, i*0.04f);
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(AppearButton());
    }

    IEnumerator AppearButton() {
        for (int i = 0; i <= 25; i++)
        {
            _playAgainButton.GetComponent<Image>().color = new Color(1, 1, 1, i*0.04f);
            _exitButton.GetComponent<Image>().color = new Color(1, 1, 1, i*0.04f);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
