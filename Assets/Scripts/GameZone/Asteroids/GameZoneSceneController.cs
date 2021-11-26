using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameZoneSceneController : MonoBehaviour
{
    [SerializeField] Text _score, _reward, _endReward, _timer;
    [SerializeField] AudioSource _timerAudio;
    [SerializeField] GameObject _gameOverPanel, _readyPanel;
    public int sec;
    int score = 0;
    int money = 0;

    public static GameZoneSceneController instance;

    MusicController music;

    AddController add;


    private void Awake() {
        music = FindObjectOfType<MusicController>();
        if (music != null)
            music.ChangeMusic("Yeap - Invaders");
        add = FindObjectOfType<AddController>();
        instance = this;
        Time.timeScale = 0;
    
    }

    private void Start()
    {
        
        StartCoroutine(StartTimer());
    }

    public void UpdateScore() {
        score++;
        money += 5;

        _score.text = "Score: " + score.ToString();
        _reward.text = money.ToString();
        _endReward.text = "+" + money.ToString();
    }


    public void StartGame() {
        if (Money.GetMoney() >= 70)
        {
            Time.timeScale = 1;
            Money.ChangeMoney(-70);
            _timerAudio.Play();
            _readyPanel.SetActive(false);
            Events.instance.Notify(EventTypes.CANVAS_DISABLE);
        }
    }

    public void RecieveAward(int multipler)
    {
        if (multipler == 2)
        {
            add.TryShowAdd();
        }

        Money.ChangeMoney(money * multipler);
        Money.ChangeFloppyDisks(5 * multipler);

        ReturnToHome();
    }


    public void ReturnToHome() {
        if (music != null)
            music.SetStandartMusic();
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator StartTimer()
    {
        for (int i = sec; i >= 0; i--)
        {
            _timer.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        _timerAudio.Stop();
    }
}
