using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElectricGameController : MonoBehaviour
{
    [SerializeField] Text _scoreText;  // Текст счёта
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] Text _moneyPrice, _disketsPrice;

    public int sec;  // Количество секунд для таймера
    [SerializeField] Text _timerText;  // Текст - таймер
    [SerializeField] AudioSource _audioSource;

    public int score;  // Счёт игрока
    public static ElectricGameController instance;

    public bool gameOver { get; private set; }

    Award award;

    MusicController music;

    AddController add;

    private void Awake() {
        instance = this;
        if (!SettingsController.musicIsOn)
            _audioSource.Stop();

        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        StartCoroutine(StartTimer());
        gameOver = false;
        music = FindObjectOfType<MusicController>();
        if (music != null)
            music.ChangeMusic("Yeap - Get a Job!");
        add = FindObjectOfType<AddController>();
    }

    public void UpdateScoreText() {
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

        Money.ChangeFloppyDisks(award.numberDiskets);
        Money.ChangeMoney(award.numberMoney);

        ReturnToHome();
    }

    IEnumerator StartTimer()
    {
        for (int i = sec; i >= 0; i--)
        {
            _timerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        if (_audioSource != null)
            _audioSource.Stop();

        gameOver = true;
        GameOver();
    }
}
