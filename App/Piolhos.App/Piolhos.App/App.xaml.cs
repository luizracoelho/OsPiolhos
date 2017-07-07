using Piolhos.App.Views;
using Plugin.Geolocator;

using Xamarin.Forms;

namespace Piolhos.App
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var locator = CrossGeolocator.Current;
            locator.AllowsBackgroundUpdates = true;

            MainPage = new NavigationPage(new HomePage());
		}

		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
