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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            telefoneEntry.Focus();
        }

        private void TelefoneEntry_Completed(object sender, System.EventArgs e)
        {
            senhaEntry.Focus();
        }

        private void SenhaEntry_Completed(object sender, System.EventArgs e)
        {
            entrarCommand.Command.Execute(null);
        }
    }
}