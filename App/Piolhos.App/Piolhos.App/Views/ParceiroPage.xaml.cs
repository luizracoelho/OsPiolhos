using Piolhos.App.Interfaces;
using Piolhos.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Piolhos.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParceiroPage : ContentPage, IMessage
	{
        ParceiroViewModel _viewModel;

        public ParceiroPage(Empresa empresa)
        {
            InitializeComponent();

            _viewModel = new ParceiroViewModel
            {
                Message = this,
                Navigation = Navigation,
                Model = empresa
            };
            BindingContext = _viewModel;
        }
    }
}