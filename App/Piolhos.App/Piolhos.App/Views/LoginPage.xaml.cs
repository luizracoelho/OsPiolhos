using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage, IMessage
	{
		public LoginPage ()
		{
			InitializeComponent ();

            var viewModel = new LoginViewModel
            {
                Message = this,
                Navigation = Navigation
            };
            BindingContext = viewModel;
		}
	}
}