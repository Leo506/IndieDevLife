using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupClass : MonoBehaviour
{
    [SerializeField] Sprite[] _pars;
    [SerializeField] UnityEngine.UI.Image[] _cards;

    // Start is called before the first frame update
    void Start()
    {
        Events.instance.Notify(EventTypes.PROGRAMMER_SET_UP);

        for (int i = 0; i < _pars.Length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                var card = Random.Range(0, _cards.Length);
                while(_cards[card] == null) card = Random.Range(0, _cards.Length);
                _cards[card].GetComponent<CardClass>().SetCardSprite(_pars[i]);
                _cards[card] = null;
            }
        }
    }
}
