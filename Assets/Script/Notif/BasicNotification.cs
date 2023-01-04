using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;



public class BasicNotification : MonoBehaviour
{
    
     void Start()
    {
        // Remove Notification That Have Already Been Displayed
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        //manage Notification Channel
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //Simple Notification
        var notification = new AndroidNotification();
        notification.Title = "Hey! Come back!";
        notification.Text = "RunGame Has New Update";
        notification.FireTime = System.DateTime.Now.AddSeconds(45);
        notification.ShowTimestamp = true;

        //Set Icon
        notification.SmallIcon = "app_icon_small";
        notification.LargeIcon = "app_icon_large";

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

        



    }
}
    
