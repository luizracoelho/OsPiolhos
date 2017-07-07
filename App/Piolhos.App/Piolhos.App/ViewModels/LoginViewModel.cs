using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using Piolhos.App.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class LoginViewModel : EntityViewModel<Login>
    {
        LoginLogic _logic;

        public LoginViewModel()
        {
            _logic = new LoginLogic();

            Init();
        }

        void Init()
        {
            Model = new Login();
        }

        #region Commands
        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (string.IsNullOrEmpty(Model.Telefone) || string.IsNullOrEmpty(Model.Senha))
                            await Message.DisplayAlert("Atenção", "Todos os campos são obrigatórios.", "Ok");
                        else
                            try
                            {
                                IsWaiting = true;

                                var retorno = await _logic.LoginAsync(Model);

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
                }));
            }
        }
        #endregion
    }
}
