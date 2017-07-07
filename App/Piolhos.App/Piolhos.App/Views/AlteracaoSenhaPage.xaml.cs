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
	}
}