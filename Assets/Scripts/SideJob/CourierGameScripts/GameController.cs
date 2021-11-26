using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance {get; private set;}

    public bool gameOver {get; private set;}  // Переменная определяющая, закончена ли игра

    public bool packageIsDelivered;  // Переменная определяющая, доставлена ли посылка

    int score;  // Счёт игрока

    public int sec;
    
    [SerializeField] Text _scoreText;  // Текст со счётом игрока
    [SerializeField] Slider _timer;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] Text _moneyPrice, _disketsPrice;
    [SerializeField] AudioSource _audioSource;

    Award award;

    MusicController music;

    AddController add;

    // Start is called before the first frame update
    void Awake()
    {
        packageIsDelivered = true;
        instance = this;
        gameOver = false;

        if (!SettingsController.musicIsOn)
            _audioSource.Stop();

        StartCoroutine(StartTimer());

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        music = FindObjectOfType<MusicController>();
        if (music != null)
            music.ChangeMusic("Yeap - Get a Job!");

        add = FindObjectOfType<AddController>();
        Debug.Log("Add: " + (add != null));
    }

    // Метод обновления количества очков
    public void UpdateScore() {
        score++;
        _scoreText.text = "Score: " + score;
    }

    // Метод возврата в комнату после работы
    public void ReturnToHome() {
        if (music != null)
            music.SetStandartMusic();
        
        SceneManager.LoadScene("LoadingScene");
    }

    void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);

        award = AwardController.GetAward(2, score);
        _disketsPrice.text = award.numberDiskets.ToString();
        _moneyPrice.text = award.numberMoney.ToString();

        Events.instance.Notify(EventTypes.JOB_FINISH);
    }

    public void RecieveAward(int multipler)
    {
        if (multipler == 2)
        {
            add.TryShowAdd();
        }
        Money.ChangeMoney(award.numberMoney * multipler);
        Money.ChangeFloppyDisks(award.numberDiskets * multipler);

        ReturnToHome();
    }

    IEnumerator StartTimer()
    {
        _timer.maxValue = sec * 100;
        _timer.value = _timer.maxValue;

        for (int i = (int)_timer.maxValue; i >= 0; i--)
        {
            _timer.value--;
            yield return new WaitForSeconds(0.01f);
        }

        if (_audioSource != null)
            _audioSource.Stop();

        GameOver();
    }
}
