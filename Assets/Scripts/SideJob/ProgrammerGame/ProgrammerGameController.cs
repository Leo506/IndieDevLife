using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ProgrammerGameController : MonoBehaviour
{
    int countOfOpenCards;

    Image _card1, _card2;

    int score = 0;  // Счёт

    [SerializeField] Slider _timer;  // Слайдер - таймер
    [SerializeField] Text _score, _moneyText, _disketsText;  // Текст счёта, монет и дискет
    [SerializeField] GameObject _victoryPanel, _gameOverPanel;  // Панели конца игры (победы и поражения)
    [SerializeField] AudioSource _timerAudio;

    Award award;

    MusicController music;

    AddController add;

    private void Awake()
    {
        if (!SettingsController.musicIsOn)
            _timerAudio.Stop();

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void Start() {
        music = FindObjectOfType<MusicController>();
        if (music != null)
            music.ChangeMusic("Yeap - Get a Job!");
        add = FindObjectOfType<AddController>();
        
        StartCoroutine(StartTimer());
    }


    // Метод, возвращающий количество открытых карт
    public int GetCountOfOpenCards() {
        countOfOpenCards = 0;

        foreach (var item in FindObjectsOfType<CardClass>())
        {
            if (!item.isHidden) countOfOpenCards++; 
        }

        return countOfOpenCards;
    }


    // Метод, проверающий на соответствие 2 карты
    public void Check(Image card) {
        if (_card1 == null) {
            _card1 = card;
        } else {
            _card2 = card;

            StartCoroutine(Check());
        }
    }

    public void ReturnToHome() {
        if (music != null)
            music.SetStandartMusic();
        SceneManager.LoadScene("LoadingScene");
    }


    IEnumerator Check() {

        if (_card1.sprite == _card2.sprite) {

                score++;
                _score.text = score.ToString();
                Events.instance.Notify(EventTypes.GOOD);

                if (score == 6) GameOver(true);

                yield return new WaitForSeconds(0.25f);
                
                _card1.gameObject.SetActive(false);
                _card2.gameObject.SetActive(false);
            
            } else {
                Events.instance.Notify(EventTypes.BAD);
                
                yield return new WaitForSeconds(1f);
                
                _card1.GetComponent<CardClass>().CloseCard();
                _card2.GetComponent<CardClass>().CloseCard();
            }

            _card1 = _card2 = null;
    }


    IEnumerator StartTimer() {

        for (int i = 500; i > 0; i--)
        {
            _timer.value = i;
            yield return new WaitForSeconds(0.03f);
        }

        GameOver(false);
        _timerAudio.Stop();

    }

    void GameOver(bool isVictory) {

        if (isVictory) {
            Time.timeScale = 0;
            _victoryPanel.SetActive(true);

            // Получение награды
            award = AwardController.GetAward(2, score);
            _disketsText.text = award.numberDiskets.ToString();
            _moneyText.text = award.numberMoney.ToString();

            Events.instance.Notify(EventTypes.SUCCESS);
        } else {
            _gameOverPanel.SetActive(true);
            Money.ChangeMoney(150);
            Events.instance.Notify(EventTypes.FAILED);
        }
    }

    public void RecieveAward(int multipler)
    {
        if (multipler == 2)
        {
            add.TryShowAdd();
        }

        Money.ChangeFloppyDisks(award.numberDiskets * multipler);
        Money.ChangeMoney(award.numberMoney * multipler);

        ReturnToHome();
    }
}
