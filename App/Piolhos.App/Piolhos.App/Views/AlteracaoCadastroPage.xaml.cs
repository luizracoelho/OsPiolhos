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
	}
}