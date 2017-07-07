using Android.App;
using Android.Util;
using Firebase.Iid;

namespace Piolhos.App.Droid.Notifications
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseInstanceIdService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIdService";

        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);

            SendRegistrationToServer(refreshedToken);
        }

        void SendRegistrationToServer(string refreshedToken)
        {

        }
    }
}