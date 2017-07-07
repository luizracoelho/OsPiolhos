using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage, IMessage
    {
        public TabPage ()
        {
            InitializeComponent();

            var viewModel = new TabViewModel
            {
                Message = this,
                Navigation = Navigation
            };
            BindingContext = viewModel;
        }
    }
}