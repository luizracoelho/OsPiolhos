using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage, IMessage
    {
        public HomePage()
        {
            InitializeComponent();
            var viewModel = new HomeViewModel
            {
                Message = this,
                Navigation = this.Navigation,
            };
            BindingContext = viewModel;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return;
            ((ListView)sender).SelectedItem = null;
        }
    }
}