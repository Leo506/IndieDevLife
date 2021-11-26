using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HackatonController : MonoBehaviour
{
    [SerializeField] Image _phoneImage;
    [SerializeField] AudioSource _audioSource;
    public static HackatonController instance;

    private void Awake() {
        instance = this;
    }

    public void Notify(bool enable)
    {
        if (enable)
            Events.instance.Notify(EventTypes.CANVAS_ENABLE);
        else
            Events.instance.Notify(EventTypes.CANVAS_DISABLE);
    }

    public void StartHackaton() {
        SceneManager.LoadScene("Hackaton");
    }


    // Включения вибрирующего телефона (уведомление об хакатоне)
    public void StartHackatonScene() {
        if (UIController.IsPlayerInUI()) {
            StartCoroutine(Waiting());
        } else {
            _phoneImage.gameObject.SetActive(true);
            if (SettingsController.soundsIsOn)
                _audioSource.Play();
            PlayerMovement.instance.CantMove();
        }
    }


    IEnumerator Waiting() {
        yield return new WaitUntil(() => !UIController.IsPlayerInUI());

        _phoneImage.gameObject.SetActive(true);
        if (SettingsController.soundsIsOn)
            _audioSource.Play();
        PlayerMovement.instance.CantMove();
    }
}
