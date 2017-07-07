using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Plugin.Permissions;
using System.Threading.Tasks;
using Firebase;
using Firebase.Iid;
using Firebase.Messaging;
using Android.Content;
using Piolhos.App.Droid.Notifications;

namespace Piolhos.App.Droid
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var senderId = "537007328900";

            var options = new FirebaseOptions.Builder()
                                .SetApplicationId("1:537007328900:android:08ab18baae5590c0")
                                .SetApiKey("AIzaSyDo1EkVamjhpceWdXcmxAPRYqbLEtMNLTw")
                                .SetGcmSenderId(senderId)
                                .Build();

            var firebaseApp = FirebaseApp.InitializeApp(this, options);

            Task.Run(() =>
            {
                var instanceID = FirebaseInstanceId.Instance;
                instanceID.DeleteInstanceId();
                var iid1 = instanceID.Token;
                var iid2 = instanceID.GetToken(senderId, Firebase.Messaging.FirebaseMessaging.InstanceIdScope);
                Console.WriteLine("Iid1: {0}, iid2: {1}", iid1, iid2);
            });

            FirebaseMessaging.Instance.SubscribeToTopic("global");

            LoadApplication(new Piolhos.App.App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}

