using Android.App;
using Android.Content;
using Android.OS;
using Firebase.Messaging;
using Xamarin.Forms;

namespace Piolhos.App.Droid.Notifications
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            RemoteMessage.Notification notification = message.GetNotification();

            ShowAlert(notification);
        }

        private void ShowAlert(RemoteMessage.Notification notification)
        {
            Looper.Prepare();
            AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
            builder.SetTitle(notification.Title);
            builder.SetMessage(notification.Body);
            builder.SetNegativeButton("Ok", (s, a) => { });

            AlertDialog alert = builder.Create();
            alert.Show();
            Looper.Loop();
        }
    }
}