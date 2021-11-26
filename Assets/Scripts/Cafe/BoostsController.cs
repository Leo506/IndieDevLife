using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoostsController : MonoBehaviour, IObserver
{
    int[] prices = { 100, 200, 300, 500 };

    [SerializeField] Image _foodEffectImage, _energyEffectImage, _creativityEffectImage, _talantEffectImage;
    [SerializeField] Text _foodTimer, _energyTimer;


    private void Start()
    {
        if (Boosts.IsPlayerOnFood())
            StartCoroutine(EffectTimer(_foodEffectImage, _foodTimer, Boosts.startFoodTime.AddMinutes(5)));

        if (Boosts.IsPlayerOnEnergy())
            StartCoroutine(EffectTimer(_energyEffectImage, _energyTimer, Boosts.startEnergyTime.AddMinutes(5)));

        if (Boosts.IsPlayerOnCreativity())
            _creativityEffectImage.gameObject.SetActive(true);

        if (Boosts.IsPlayerOnTalant())
            _talantEffectImage.gameObject.SetActive(true);

        Events.instance.AddObserver(this);
    }


    public void BuyBoost(int boostIndex)
    {
        if (Money.GetFloppyDisks() >= prices[boostIndex])
        {
            switch (boostIndex)
            {
                case 0:
                    if (!Boosts.IsPlayerOnEnergy())
                    {
                        Boosts.BuyEnergyCocktail(prices[boostIndex]);
                        StartCoroutine(EffectTimer(_energyEffectImage, _energyTimer, Boosts.startEnergyTime.AddMinutes(5)));
                        Events.instance.Notify(EventTypes.BUY);
                    } else
                    {
                        Events.instance.Notify(EventTypes.BAD);
                    }
                    break;

                case 1:
                    if (!Boosts.IsPlayerOnFood())
                    {
                        Boosts.BuyFoodCocktail(prices[boostIndex]);
                        StartCoroutine(EffectTimer(_foodEffectImage, _foodTimer, Boosts.startFoodTime.AddMinutes(5)));
                        Events.instance.Notify(EventTypes.BUY);
                    } else
                    {
                        Events.instance.Notify(EventTypes.BAD);
                    }
                    break;

                case 2:
                    if (!Boosts.IsPlayerOnCreativity())
                    {
                        Boosts.BuyCreativityCocktail(prices[boostIndex]);
                        _creativityEffectImage.gameObject.SetActive(true);
                        Events.instance.Notify(EventTypes.BUY);
                    } else
                    {
                        Events.instance.Notify(EventTypes.BAD);
                    }
                    break;

                case 3:
                    if (!Boosts.IsPlayerOnTalant())
                    {
                        Boosts.BuyTalantCocktail(prices[boostIndex]);
                        _talantEffectImage.gameObject.SetActive(true);
                        Events.instance.Notify(EventTypes.BUY);
                    } else
                    {
                        Events.instance.Notify(EventTypes.BAD);
                    }
                    break;

                default:
                    break;
            }
        }
        else
        {
            Events.instance.Notify(EventTypes.BAD);
        }
    }

    IEnumerator EffectTimer(Image effectImage, Text timerText, DateTime endTime)
    {
        effectImage.gameObject.SetActive(true);

        while (DateTime.Now <= endTime)
        {
            var diff = endTime - DateTime.Now;
            timerText.text = $"{diff.Minutes}:{diff.Seconds}";
            yield return new WaitForSeconds(1);
        }

        effectImage.gameObject.SetActive(false);
    }

    public void OnNotify(EventTypes eventType)
    {
        if (eventType == EventTypes.GAME_PUBLISHED)
        {
            Boosts.DisableCreativityEffect();
            _creativityEffectImage.gameObject.SetActive(false);
        }
    }
}
