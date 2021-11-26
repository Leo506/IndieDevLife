using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsController : MonoBehaviour//, //IObserver
{
    [SerializeField] AchieveButton[] _achieveButtons;
    [SerializeField] AchievNotifyController notifyController;

    public void ShowAchieveData() {
        foreach (var item in _achieveButtons)
        {
            if (item.gameObject.activeSelf)
            {
                item.ShowAchieveProgress();
            }
        }
    }

    private void Start()
    {
        for (int i = 0; i < AchievementsList.progress.Length; i++)
        {
            if (!AchievementsList.progress[i].priceIsGotten && AchievementsList.progress[i].GetCurrentProgress() == 1) {
                notifyController.AddRecievedAchievements(_achieveButtons[i]);
                Events.instance.Notify(EventTypes.ACHIEVEMENT_GOT);
            }
                
        }
    }

    public AchieveButton GetAchieveButton(int index)
    {
        return _achieveButtons[index];
    }


    /*public void OnNotify(EventTypes eventType)
    {
        for (int i = 0; i < _achieveButtons.Length; i++)
        {
            AchieveItem item = AchievementsList.progress[i];

            if (item.myEventType == eventType)
            {
                if (item.GetCurrentProgress() == 1)
                {
                    Debug.Log("Достижение полученно!");
                    notifyController.AddRecievedAchievements(i);
                    Events.instance.Notify(EventTypes.ACHIEVEMENT_GOT);
                    _achieveButtons[i].ShowAchieveProgress();
                }
            }
        }
    }*/
}
