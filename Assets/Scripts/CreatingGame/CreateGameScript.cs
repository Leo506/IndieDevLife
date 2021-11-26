using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateGameScript : MonoBehaviour, IObserver
{
    [SerializeField] Slider _progressSlider;                      // Слайдер прогресса создания игры
    [SerializeField] Text _alertText;                             // Сообщение об завершении создания игры
    [SerializeField] InputField _gameNameField;                   // Текстовое поле для введения названия игры
    [SerializeField] Text _creativityLvlText;                     // Текст с бонусом от уровня креативности
    [SerializeField] Text _timeToCreateGameText;                  // Текст с временем создания игры
    [SerializeField] Button _createGameButton;                    // Кнопка создания игры
    [SerializeField] GameObject _crunchPanel;                     // Кранч-панель
    [SerializeField] AudioSource audioSource;                     // Источник звука для вывода звука нажатия на клавиши
    [SerializeField] SpriteRenderer _pointer;                     // Указатель на компьютер (изменяется при процессе создания игры)
    [SerializeField] Sprite _usuallySprite, _gameCreatingSprite, _gameCreatedSprite;
    [SerializeField] Button _skipButton;
    [SerializeField] Text _priceToSkip;

    string gameName;                                              // Название игры (для сохранения названия между сценами)
    bool nowCrunch;
    GameCreator creator;

    private void Start()
    {
        creator = FindObjectOfType<GameCreator>();

        if (CreatingGameInfo.gameState == GameState.GameCreated)
            ChangePointer(_gameCreatedSprite);
        else if (CreatingGameInfo.gameState == GameState.GameIsCreating)
            ChangePointer(_gameCreatingSprite);

        Events.instance.AddObserver(this);
    }

    // Метод вызываемый при активации Canvas'а
    public void Enable()
    {
        CreateGameUtils.UpdatePriceToSkip();

        switch (CreatingGameInfo.gameState)
        {
            case GameState.GameIsCreating:
                EnableCreateGameButton(false);
                SetUp();
                ShowProgress();
                break;

            case GameState.GameCreated:
                Finish();
                break;

            case GameState.NoGame:
                EnableCreateGameButton(true);
                SetUp();
                break;

            default:
                break;
        }

    }


    void SetUp()
    {
        _creativityLvlText.text = "+" + SkillsLvl.creativityLvl.ToString() + "%";
        _timeToCreateGameText.text = (CreatingGameInfo.TimeToCreateGame/10).ToString() + " сек";
        
        _alertText.gameObject.SetActive(false);
        _progressSlider.gameObject.SetActive(true);
        
        _progressSlider.maxValue = CreatingGameInfo.TimeToCreateGame;
        _progressSlider.value = _progressSlider.maxValue;

        if (CreatingGameInfo.GameName != "")
            _gameNameField.text = CreatingGameInfo.GameName;
    }


    // Включение/выключение кнопки создания игры
    void EnableCreateGameButton(bool active)
    {
        _createGameButton.enabled = active;
    }


    // Отображение прогресса создания игры
    void ShowProgress()
    {
        StartCoroutine(ShowProgressSlider());
    }




    // Метод, вызываемый при нажатии на кнопку создания игры
    public void CreateGame()
    {
        gameName = _gameNameField.text;
        CreatingGameInfo.GameName = gameName;

        creator.StartCreateGame(CreatingGameInfo.TimeToCreateGame);    // Старт создания игры
        
        ChangePointer(_gameCreatingSprite);                            // Изменение указателя на компьютер
        
        if (SettingsController.musicIsOn)
            audioSource.Play();
        
        CreatingGameInfo.gameState = GameState.GameIsCreating;         // Изменение состояния создания игры
        
        EnableCreateGameButton(false);

        if (IsCrunchNow())
        {
            nowCrunch = true;
            _crunchPanel.SetActive(true);
        } else
        {
            nowCrunch = false;
        }

        ShowProgress();
    }

    void ChangePointer(Sprite sprite)
    {
        _pointer.sprite = sprite;
    }


    // Метод закрытия Canvas'а
    public void Back()
    {
        audioSource.Stop();
        StopAllCoroutines();
    }


    // Определяем, кранч ли сейчас
    bool IsCrunchNow()
    {
        var crunch = UnityEngine.Random.Range(1, CreatingGameInfo.ChanceToCrunch);
        if (crunch == 1)
            return true;

        return false;
    }

    private void Update()
    {
        if (nowCrunch)
        {
            if (Input.anyKeyDown)
            {
                GameCreator.instance.OnCrunch();
            }
        }
    }

    public void Finish()
    {
        StartCoroutine(ShowAlert());

        ChangePointer(_usuallySprite);

        GamesArchive.AddGame(CreatingGameInfo.GameName);

        Events.instance.Notify(EventTypes.GAME_CREATED);
        Events.instance.Notify(EventTypes.SUCCESS);

        CreateGameUtils.UpdateTimeToCreateGame();
        CreateGameUtils.UpdatePriceToSkip();
        CreatingGameInfo.gameState = GameState.NoGame;

        Player.AddSkillPoint(2);

        audioSource.Stop();

        EnableCreateGameButton(true);

        _crunchPanel.SetActive(false);
        _skipButton.gameObject.SetActive(false);
    }

    public void OnNotify(EventTypes eventType)
    {
        if (eventType == EventTypes.END_CREATING)
            ChangePointer(_gameCreatedSprite);
    }

    public void Skip()
    {
        if (Money.GetFloppyDisks() >= CreatingGameInfo.PriceToSkip)
        {
            Money.ChangeFloppyDisks(-CreatingGameInfo.PriceToSkip);
            creator.SkipTime();
        }
    }

    IEnumerator ShowProgressSlider()
    {
        while (creator.GetCreatingProgress() > 0)
        {
            _progressSlider.value = creator.GetCreatingProgress();

            if (creator.GetCreatingProgress() <= 6400)
            {
                _skipButton.gameObject.SetActive(true);
                _priceToSkip.text = CreatingGameInfo.PriceToSkip.ToString();
            }

            yield return new WaitForSeconds(0.01f);
        }

        Finish();
    }

    IEnumerator ShowAlert()
    {
        _progressSlider.gameObject.SetActive(false);
        _alertText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        SetUp();
    }
}
