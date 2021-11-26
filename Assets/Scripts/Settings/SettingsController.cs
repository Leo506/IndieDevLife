using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Image _musicOnOffButton, _langButton, _soundsButton;
    [SerializeField] LeanLocalization _localization;
    [SerializeField] Sprite _onSprite, _offSprite, _ruSprite, _engSprite;

    MusicController musicController;

    public static bool musicIsOn = true;
    public static bool langIsRus = true;
    public static bool soundsIsOn = true;

    private void Start() {
        musicController = FindObjectOfType<MusicController>();
        SetUpMusic();
        SetUpLanguage();
        SetUpSounds();
    }


    public void OnOfMusic() {
        if (musicController.itSource.isPlaying) {
            musicController.Off();
            _musicOnOffButton.sprite = _offSprite;
        } else {
            musicController.On();
            _musicOnOffButton.sprite = _onSprite;
        }

        musicIsOn = !musicIsOn;
    }

    void SetUpMusic()
    {
        if (musicController != null) {
            if (musicIsOn)
            {
                _musicOnOffButton.sprite = _onSprite;
                musicController.On();
            }
            else
            {
                _musicOnOffButton.sprite = _offSprite;
                musicController.Off();
            }
        }
        
    }

    void SetUpLanguage()
    {
        if (langIsRus)
        {
            _localization.SetCurrentLanguage("Russian");
            Language.currentLanguage = "Russian";
            _langButton.sprite = _ruSprite;
        } else
        {
            _localization.SetCurrentLanguage("English");
            Language.currentLanguage = "English";
            _langButton.sprite = _engSprite;
        }
    }

    public void ChangeLanguage()
    {
        if (Language.currentLanguage == "Russian")
        {
            _localization.SetCurrentLanguage("English");
            Language.currentLanguage = "English";
            _langButton.sprite = _engSprite;
        } else
        {
            _localization.SetCurrentLanguage("Russian");
            Language.currentLanguage = "Russian";
            _langButton.sprite = _ruSprite;
        }

        langIsRus = !langIsRus;
    }

    public void OnOfSounds()
    {
        if (soundsIsOn)
        {
            soundsIsOn = false;
            _soundsButton.sprite = _offSprite;
        } else
        {
            soundsIsOn = true;
            _soundsButton.sprite = _onSprite;
        }
    }

    void SetUpSounds()
    {
        if (soundsIsOn)
        {
            _soundsButton.sprite = _onSprite;
        } else
        {
            _soundsButton.sprite = _offSprite;
        }
    }
}
