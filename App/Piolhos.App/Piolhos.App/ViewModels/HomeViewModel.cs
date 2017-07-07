using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using Piolhos.App.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Init();
        }

        private void Init()
        {
            IsWaiting = true;

            var logic = new LoginLogic();

            var login = logic.Get();

            if (login == null)
                IsWaiting = false;
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        var retorno = await logic.LoginAsync(login);

                        if (retorno)
                            App.Current.MainPage = new RootPage();
                        else
                            throw new ArgumentNullException();
                    }
                    catch (ArgumentNullException)
                    {
                        IsWaiting = false;
                        await Message.DisplayAlert("Erro", "Telefone ou senha inválidos.", "Ok");
                    }
                    catch (Exception)
                    {
                        IsWaiting = false;
                        await Message.DisplayAlert("Erro", "Não foi possível conectar-se ao servidor, tente novamente em breve.", "Ok");
                    }
                });
            }
        }

        #region Commands
        private ICommand _cadastroCommand;
        public ICommand CadastroCommand
        {
            get
            {
                return _cadastroCommand ?? (_cadastroCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushAsync(new CadastroPage());
                    });
                }));
            }
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushAsync(new LoginPage());
                    });
                }));
            }
        }
        #endregion
    }
}
