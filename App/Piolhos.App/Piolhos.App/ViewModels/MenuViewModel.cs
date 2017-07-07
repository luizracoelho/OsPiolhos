using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using Piolhos.App.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region Commands
        private ICommand _alterarCadastroCommand;
        public ICommand AlterarCadastroCommand
        {
            get
            {
                return _alterarCadastroCommand ?? (_alterarCadastroCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var rootPage = App.Current.MainPage as RootPage;

                        rootPage.IsPresented = false;
                        await rootPage.Detail.Navigation.PushAsync(new AlteracaoCadastroPage());
                    });
                }));
            }
        }

        private ICommand _alterarSenhaCommand;
        public ICommand AlterarSenhaCommand
        {
            get
            {
                return _alterarSenhaCommand ?? (_alterarSenhaCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var rootPage = App.Current.MainPage as RootPage;

                        rootPage.IsPresented = false;
                        await rootPage.Detail.Navigation.PushAsync(new AlteracaoSenhaPage());
                    });
                }));
            }
        }

        private ICommand _sairCommand;
        public ICommand SairCommand
        {
            get
            {
                return _sairCommand ?? (_sairCommand = new Command(() =>
                {
                    var logic = new LoginLogic();

                    logic.Logout();

                    App.Current.MainPage = new NavigationPage(new HomePage());
                }));
            }
        }
        #endregion
    }
}
