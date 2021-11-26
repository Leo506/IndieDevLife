using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatisticController : MonoBehaviour, IObserver
{
    [SerializeField] GameObject _gameName;
    [SerializeField] GameObject _recivedMoney;
    [SerializeField] UnityEngine.UI.Text _prefab;

    // Start is called before the first frame update
    public void Start()
    {
        var soldGames = GamesArchive.GetGames();

        for (int i = 0; i < soldGames.Count; i++)
        {
            var a = Instantiate(_prefab, _gameName.transform);
            var b = Instantiate(_prefab, _recivedMoney.transform);
            a.text = soldGames[i].name;
            b.text = soldGames[i].receivedMoney.ToString();
        }

        Events.instance.AddObserver(this);
    }

    public void OnNotify(EventTypes eventType)
    {
        if (eventType == EventTypes.GAME_CREATED)
        {
            var soldGames = GamesArchive.GetGames();

            var a = Instantiate(_prefab, _gameName.transform);
            var b = Instantiate(_prefab, _recivedMoney.transform);

            a.text = soldGames[soldGames.Count - 1].name;
            b.text = soldGames[soldGames.Count - 1].receivedMoney.ToString();
        }
    }

}
