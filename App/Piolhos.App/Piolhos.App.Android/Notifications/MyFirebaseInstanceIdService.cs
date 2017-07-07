using Android.App;
using Firebase.Iid;

namespace Piolhos.App.Droid.Notifications
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseInstanceIdService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        public override void OnTokenRefresh()
        {
            // Get updated InstanceID token.
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Android.Util.Log.Debug(TAG, "Refreshed token: " + refreshedToken);

            // TODO: Implement this method to send any registration to your app's servers.
            SendRegistrationToServer(refreshedToken);
        }

        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
}