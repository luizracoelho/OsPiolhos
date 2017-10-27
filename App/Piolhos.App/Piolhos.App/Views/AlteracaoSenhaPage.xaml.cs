using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlteracaoSenhaPage : ContentPage, IMessage
	{
		public AlteracaoSenhaPage ()
		{
			InitializeComponent ();

            var viewModel = new AlteracaoSenhaViewModel
            {
                Message = this,
                Navigation = Navigation
            };
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            senhaAtualEntry.Focus();
        }

        private void SenhaAtualEntry_Completed(object sender, System.EventArgs e)
        {
            senhaEntry.Focus();
        }

        private void SenhaEntry_Completed(object sender, System.EventArgs e)
        {
            confirmarSenhaEntry.Focus();
        }

        private void ConfirmarSenhaEntry_Completed(object sender, System.EventArgs e)
        {
            confirmarCommand.Command.Execute(null);
        }
    }
}