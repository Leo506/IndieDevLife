using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RouletteController : MonoBehaviour
{
    [SerializeField] Text _numberOfDiskets;  // текст с количеством дискет
    [SerializeField] InputField _betNumber;  // Размер ставки
    [SerializeField] int startBet;  // Начальная ставка
    [SerializeField] GameObject _roulette;

    MusicController music;

    int currentBet;  // Текущая ставка

    int[] multiplies = { 3, 1, 0, 1, 1, 2, 1, 2, 5, 1, 1, 0 };

    // Start is called before the first frame update
    void Start()
    {
        _numberOfDiskets.text = Money.GetFloppyDisks().ToString();
        _betNumber.text = startBet.ToString();
        music = FindObjectOfType<MusicController>();
        music.ChangeMusic("Yeap - Bye, my money");
    }


    // Метод для изменения ставки
    public void ChangeBet(int value)
    {
        int bet = int.Parse(_betNumber.text);
        if ((bet + value) <= Money.GetFloppyDisks())
        {
            bet += value;
            _betNumber.text = bet.ToString();
        }
    }


    // Метод начала прокрутки рулетки
    public void StartSpin()
    {
        currentBet = int.Parse(_betNumber.text);

        if (currentBet <= Money.GetFloppyDisks()-10)
        {
            Money.ChangeFloppyDisks(-currentBet);
            Money.ChangeFloppyDisks(-10);
            _numberOfDiskets.text = Money.GetFloppyDisks().ToString();

            int priceIndex = Random.Range(0, multiplies.Length);
            float spinAngle = 1080 + 30 * priceIndex;
            StartCoroutine(Spinning(spinAngle, priceIndex));
        }
    }

    IEnumerator Spinning(float angle, int index)
    {
        var anglePerPeriod = (angle / 3) / 100;


        for (int i = 1; i <= 300; i++)
        {
            var zRotation = anglePerPeriod * i;
            _roulette.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            yield return new WaitForSeconds(0.01f);
        }

        Money.ChangeFloppyDisks(currentBet * multiplies[index]);
        _numberOfDiskets.text = Money.GetFloppyDisks().ToString();
    }

    public void ReturnToHome()
    {
        music.SetStandartMusic();
        SceneManager.LoadScene("LoadingScene");
    }

}
