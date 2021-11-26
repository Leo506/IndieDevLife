using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PublisherController : MonoBehaviour, IObserver
{
    [SerializeField] Dropdown _gamesDropdown;
    [SerializeField] Text _price, _chance;

    
    // Start is called before the first frame update
    public void Start()
    {
        Events.instance.AddObserver(this);
        SetUpDropdown();
    }

    void SetUpDropdown()
    {
        _gamesDropdown.ClearOptions();
        List<string> games = new List<string>();
        foreach (var item in GamesArchive.GetAvaliableToSellGames())
        {
            games.Add(item.name);
        }

        _gamesDropdown.AddOptions(games);
    }

    void UpdatePublisher()
    {
        Publisher.SetChance(SkillsLvl.creativityLvl, GamesArchive.GetGames().Count);
        Publisher.SetPrice();
        _price.text = Publisher.GetPriceToPublish().ToString();
        _chance.text = Publisher.GetChanceToHit().ToString() + "%";
        Debug.Log("Издатель обновлён");
    }

    
    public void SellGame()
    {
        if (Money.GetMoney() >= Publisher.GetPriceToPublish())
        {
            Debug.Log("Игра издана");
            Money.ChangeMoney(-Publisher.GetPriceToPublish());

            if (IsHit()) {
                Money.ChangeMoney(1000000);
                Publisher.wasHit = true;
                SceneManager.LoadScene("HitScene");
            } else {
                int moneyToGet = 2 * (int)(150 + 100 * Random.Range(1, 4) * Publisher.GetChanceToHit() * 0.25f);
                Money.ChangeMoney(moneyToGet);
                GamesArchive.ChangeGameStatus(GamesArchive.GetAvaliableToSellGames()[_gamesDropdown.value], moneyToGet);
            }
            SetUpDropdown();
            UpdatePublisher();
            Events.instance.Notify(EventTypes.GAME_PUBLISHED);
        }
        
    }

    private bool IsHit()  {
        var chance = Random.Range(1, 101);

        if (chance <= Publisher.GetChanceToHit() && GamesArchive.GetGames().Count >= 3) {
            return true;
        }

        return false;
    }

    public void OnNotify(EventTypes eventType)
    {
        if (eventType == EventTypes.CANVAS_ENABLE)
            UpdatePublisher();
    }
}
