using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage, IMessage
	{
		public MenuPage ()
		{
			InitializeComponent ();
            var viewModel = new MenuViewModel
            {
                Message = this,
                Navigation = Navigation
            };
            BindingContext = viewModel;
		}
	}
}