
using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage, IMessage
    {
        public RootPage()
        {
            InitializeComponent();

            var viewModel = new RootViewModel
            {
                Message = this,
                Navigation = Navigation
            };
            BindingContext = viewModel;
        }
    }
}