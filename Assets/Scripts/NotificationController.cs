using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationController : MonoBehaviour
{
    private int identifier;

    private void Start()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            if (CreatingGameInfo.gameState == GameState.GameIsCreating)
            {
                var notification = new AndroidNotification();
                notification.Title = "IndieDevLife";

                if (SettingsController.langIsRus)
                    notification.Text = "Игра создана";
                else
                    notification.Text = "Game is created";

                notification.FireTime = GameCreator.CreateGameEndTime;

                identifier = AndroidNotificationCenter.SendNotification(notification, "channel_id");
            }
            
        }

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Delivered)
        {
            //Remove the notification from the status bar
            AndroidNotificationCenter.CancelNotification(identifier);
        }
    }
}
