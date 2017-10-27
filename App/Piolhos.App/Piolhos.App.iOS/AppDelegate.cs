using Firebase.CloudMessaging;
using Foundation;
using System;
using UIKit;
using UserNotifications;
using FirebaseApp = Firebase.Core.App;

namespace Piolhos.App.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUNUserNotificationCenterDelegate, IMessagingDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            
            LoadApplication(new Piolhos.App.App());

            // get permission for notification
            //if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            //{
            //    // iOS 10
            //    var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
            //    UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
            //    {
            //        Console.WriteLine(granted);
            //    });

            //    // For iOS 10 display notification (sent via APNS)
            //    UNUserNotificationCenter.Current.Delegate = this;

            //    //Messaging.SharedInstance.RemoteMessageDelegate = this;
            //    Messaging.SharedInstance.Delegate = this;
            //}
            //else
            //{
            //    // iOS 9 <=
            //    var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
            //    var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
            //}

            //UIApplication.SharedApplication.RegisterForRemoteNotifications();

            //// Firebase component initialize
            //FirebaseApp.Configure();

            //Firebase.InstanceID.InstanceId.Notifications.ObserveTokenRefresh((sender, e) =>
            //{
            //    var newToken = Firebase.InstanceID.InstanceId.SharedInstance.Token;
            //    // if you want to send notification per user, use this token
            //    System.Diagnostics.Debug.WriteLine(newToken);

            //    ConnectFCM();
            //});

            app.StatusBarHidden = false;

            return base.FinishedLaunching(app, options);
        }

        public override void DidEnterBackground(UIApplication uiApplication)
        {
            //Messaging.SharedInstance.Disconnect();
            Messaging.SharedInstance.ShouldEstablishDirectChannel = false;
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            ConnectFCM();
            base.OnActivated(uiApplication);
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
#if DEBUG
            //Firebase.InstanceID.InstanceId.SharedInstance.SetApnsToken(deviceToken, ApnsTokenType.Sandbox);
            Messaging.SharedInstance.SetApnsToken(deviceToken, ApnsTokenType.Sandbox);

#endif
#if RELEASE
			//Firebase.InstanceID.InstanceId.SharedInstance.SetApnsToken(deviceToken, Firebase.InstanceID.ApnsTokenType.Prod);
            Messaging.SharedInstance.SetApnsToken(deviceToken, ApnsTokenType.Production);
#endif
        }

        // iOS 9 <=, fire when recieve notification foreground
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            Messaging.SharedInstance.AppDidReceiveMessage(userInfo);

            // Generate custom event
            NSString[] keys = { new NSString("Event_type") };
            NSObject[] values = { new NSString("Recieve_Notification") };
            var parameters = NSDictionary<NSString, NSObject>.FromObjectsAndKeys(keys, values, keys.Length);

            // Send custom event
            Firebase.Analytics.Analytics.LogEvent("CustomEvent", parameters);

            if (application.ApplicationState == UIApplicationState.Active)
            {
                System.Diagnostics.Debug.WriteLine(userInfo);
                var aps_d = userInfo["aps"] as NSDictionary;
                var alert_d = aps_d["alert"] as NSDictionary;
                var body = alert_d["body"] as NSString;
                var title = alert_d["title"] as NSString;
                ShowAlert(title, body);
            }
        }

        // iOS 10, fire when recieve notification foreground
        [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
        public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            var title = notification.Request.Content.Title;
            var body = notification.Request.Content.Body;

            ShowAlert(title, body);
        }

        private void ConnectFCM()
        {
            //Messaging.SharedInstance.Connect((error) =>
            //{
            //    if (error == null)
            //    {
            //        Messaging.SharedInstance.Subscribe("/topics/global");
            //    }
            //    System.Diagnostics.Debug.WriteLine(error != null ? "error occured" : "connect success");
            //});


            Messaging.SharedInstance.ShouldEstablishDirectChannel = true;
            Messaging.SharedInstance.Subscribe("/topics/global");
        }

        private void ShowAlert(string title, string message)
        {
            //var alert = new UIAlertView(title ?? "Notificação", message ?? "Message", null, "OK");
            //alert.Show();

            var alertController = UIAlertController.Create(title ?? "Notificação", message ?? "Message", UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
        }

        public void DidRefreshRegistrationToken(Messaging messaging, string fcmToken)
        {
            Messaging.SharedInstance.ShouldEstablishDirectChannel = false;
        }
    }

}
