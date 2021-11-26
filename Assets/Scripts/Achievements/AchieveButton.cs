using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveButton : MonoBehaviour, IObserver
{
    [SerializeField] Image _gotImage;
    [SerializeField] Sprite _achievRUSprite, _achievEUSprite;
    [SerializeField] AchievNotifyController notifyController;
    public int index;
    AchieveItem item;

    private void Start()
    {
        item = AchievementsList.progress[index];
        Events.instance.AddObserver(this);
    }

    public void ShowAchieveProgress()
    {
        AchieveItem achieve= AchievementsList.progress[index];

        if (achieve.priceIsGotten)
        {
            _gotImage.gameObject.SetActive(true);
        }
            
    }

    public void ClaimPrice()
    {
        AchieveItem item = AchievementsList.progress[index];

        if (item.GetCurrentProgress() == 1 && !item.priceIsGotten)
        {
            if (item.TypeOfPrice == TypeOfValute.Money)
            {
                Money.ChangeMoney(item.Price);
            }
            else
            {
                Money.ChangeFloppyDisks(item.Price);
            }

            item.priceIsGotten = true;

            ShowAchieveProgress();
        }
    }

    public void OnNotify(EventTypes eventType)
    {
        if (item.myEventType == eventType)
        {
            if (item.GetCurrentProgress() == 1 && !item.priceIsGotten)
            {
                Debug.Log("Достижение полученно!");
                notifyController.AddRecievedAchievements(this);
                Events.instance.Notify(EventTypes.ACHIEVEMENT_GOT);
                ShowAchieveProgress();
            }
        }
    }

    public Sprite GetAchievSprite()
    {
        if (SettingsController.langIsRus)
            return _achievRUSprite;

        return _achievEUSprite;
    }
}
