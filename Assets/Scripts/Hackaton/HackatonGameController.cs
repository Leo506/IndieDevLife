using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HackatonGameController : MonoBehaviour
{
    [SerializeField] Text _letter;                              // Буква, которую необходимо найти
    [SerializeField] Text[] _buttonsText;                       // Массив из текстов кнопок, среди которых надо будет найти нужную букву
    [SerializeField] GameObject _gameOverPanel, _victoryPanel;  // Панели победы и проигрыша
    [SerializeField] Slider _timerSlider;                       // Таймер в виде слайдера
    [SerializeField] Image[] _hpImage, _interferenceImage;      // Массивы изображения hp и человечков-препятствий
    [SerializeField] Sprite _hpBroken;                          // Спрайт, применяющийся при неверно найденной букве (при вычитании hp)
    [SerializeField] AudioSource _timerAudio;
    [SerializeField] AddController _add;

    public int gameOverMoney;  // Деньги за проигрыш
    public int victoryMoney;   // Деньги за победу

    int getMoney;

    int lvl = 0;

    string[] alphabet = new string[]
    {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
        "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
        "W", "X", "Y", "Z"
    };

    string letter;
    int countOfFailed = 0;

    MusicController music;

    private void Awake()
    {
        if (!SettingsController.musicIsOn)
        {
            _timerAudio.Stop();
        } else
        {
            music = FindObjectOfType<MusicController>();

            if (music != null)
                music.ChangeMusic("Yeap - Funny song");
        }

        Time.timeScale = 0;
    }

    public void StartGame() {
        Time.timeScale = 1;
    }


    // Настройка, какие именно люди-препятсвия будут видимы
    void SetInterference()
    {
        for (int i = 0; i < Random.Range(0, _interferenceImage.Length); i++)
        {
            _interferenceImage[i].gameObject.SetActive(true);
        }
    }


    // Метод победы
    void Win()
    {
        StopAllCoroutines();
        _victoryPanel.SetActive(true);
        getMoney = victoryMoney;
        Events.instance.Notify(EventTypes.SUCCESS);
    }


    // Метод проигрыша
    void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        getMoney = gameOverMoney;
        Events.instance.Notify(EventTypes.FAILED);
    }


    // Настройка расположения букв
    void SetLvl()
    {
        letter = alphabet[Random.Range(0, alphabet.Length)];
        _letter.text = letter;

        foreach (var item in _buttonsText)
        {
            var let = alphabet[Random.Range(0, alphabet.Length)];
            while(let == letter) let = alphabet[Random.Range(0, alphabet.Length)];  // Заменяем повторы искомой буквы

            item.text = let;
        }

        _buttonsText[Random.Range(0, _buttonsText.Length)].text = letter;
    }


    // Метод старта уровня хакатона
    void StartLvl()
    {
        StopAllCoroutines();

        if (lvl != 9)
        {
            SetLvl();
            SetInterference();
            StartCoroutine(Timer());
            lvl++;
        }
        else
            Win();
    }


    // Метод вызываемый при ошибке игрока
    void Fail()
    {
        countOfFailed++;
        Events.instance.Notify(EventTypes.BAD);
        
        _hpImage[countOfFailed - 1].sprite = _hpBroken;
        
        if (countOfFailed == 3)
            GameOver();
        else
            StartLvl();
    }



    // Start is called before the first frame update
    void Start()
    {
        StartLvl();
    }

    public void OnClickButton(Text text)
    {

        if (text.text == letter)
            StartLvl();
        else
            Fail();
        
    }

    void ReturnToHome()
    {
        if (music != null)
            music.SetStandartMusic();

        SceneManager.LoadScene("LoadingScene");
    }

    public void RecieveAward(int multiplier)
    {
        if (multiplier == 2)
            _add.TryShowAdd();

        Money.ChangeMoney(getMoney * multiplier);
        ReturnToHome();
    }

    public void ClickOnInterference(int index)
    {
        _interferenceImage[index].gameObject.SetActive(false);
        Events.instance.Notify(EventTypes.NORMAL_CLICK);
    }


    IEnumerator Timer()
    {
        for (int i = 0; i < 250; i++)
        {
            _timerSlider.value = i;
            yield return new WaitForSeconds(0.01f);
        }
        Fail();
    }
}
