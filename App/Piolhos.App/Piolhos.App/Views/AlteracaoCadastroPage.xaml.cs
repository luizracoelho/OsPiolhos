using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlteracaoCadastroPage : ContentPage, IMessage
	{
		public AlteracaoCadastroPage ()
		{
			InitializeComponent ();

            var viewModel = new AlteracaoCadastroViewModel
            {
                Message = this,
                Navigation = Navigation
            };
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            nomeEntry.Focus();
        }

        private void NomeEntry_Completed(object sender, System.EventArgs e)
        {
            emailEntry.Focus();
        }

        private void EmailEntry_Completed(object sender, System.EventArgs e)
        {
            telefoneEntry.Focus();
        }

        private void TelefoneEntry_Completed(object sender, System.EventArgs e)
        {
            confirmarEntry.Command.Execute(null);
        }
    }
}