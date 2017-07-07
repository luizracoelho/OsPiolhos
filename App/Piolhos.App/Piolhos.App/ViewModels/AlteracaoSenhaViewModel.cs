using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using Piolhos.App.Views;
using System;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class AlteracaoSenhaViewModel : EntityViewModel<Usuario>
    {
        UsuarioLogic _usuarioLogic;
        LoginLogic _loginLogic;

        public AlteracaoSenhaViewModel()
        {
            _usuarioLogic = new UsuarioLogic();
            _loginLogic = new LoginLogic();

            Init();
        }

        void Init()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsWaiting = true;

                    var login = _loginLogic.Get();

                    Model = await _usuarioLogic.GetAsync(login.Telefone);

                    Model.Senha = null;

                    IsWaiting = false;
                }
                catch (Exception)
                {
                    IsWaiting = false;
                    await Message.DisplayAlert("Erro", "Não foi possível conectar-se ao servidor, tente novamente em breve.", "Ok");
                }
            });
        }

        #region Properties
        private string _senhaAtual;
        public string SenhaAtual
        {
            get { return _senhaAtual; }
            set
            {
                _senhaAtual = value;
                RaisedPropertyChanged(() => SenhaAtual);
            }
        }

        private string _confirmarSenha;
        public string ConfirmarSenha
        {
            get { return _confirmarSenha; }
            set
            {
                _confirmarSenha = value;
                RaisedPropertyChanged(() => ConfirmarSenha);
            }
        }
        #endregion

        #region Commands
        private ICommand _alterarSenhaCommand;
        public ICommand AlterarSenhaCommand
        {
            get
            {
                return _alterarSenhaCommand ?? (_alterarSenhaCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var hasError = false;
                        var sbError = new StringBuilder();

                        sbError.Append("Os campos abaixo são obrigatórios:\n");

                        if (string.IsNullOrEmpty(SenhaAtual))
                        {
                            hasError = true;
                            sbError.Append(" - Senha Atual\n");
                        }

                        if (string.IsNullOrEmpty(Model.Senha))
                        {
                            hasError = true;
                            sbError.Append(" - Nova Senha\n");
                        }

                        if (!hasError)
                        {
                            try
                            {
                                //Obter o login
                                var login = _loginLogic.Get();

                                if (!login.Senha.Equals(SenhaAtual))
                                    throw new ArgumentOutOfRangeException("Senha Atual", new Exception("A senha atual está incorreta."));

                                //Validar se as senhas coincidem
                                if (!Model.Senha.Equals(ConfirmarSenha))
                                    throw new ArgumentOutOfRangeException("Nova Senha", new Exception("A senha nova e a confirmação não conferem."));

                                IsWaiting = true;

                                //Salvar o usuário
                                if (await _usuarioLogic.SaveSenhaAsync(Model))
                                {
                                    login.Senha = Model.Senha;

                                    //Efetuar o login
                                    if (await _loginLogic.LoginAsync(login))
                                        App.Current.MainPage = new RootPage();
                                    else
                                        throw new ArgumentNullException();
                                }
                                else
                                    throw new ArgumentException();
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                IsWaiting = false;
                                await Message.DisplayAlert("Atenção", ex.InnerException.Message, "Ok");
                            }
                            catch (ArgumentNullException)
                            {
                                IsWaiting = false;
                                await Message.DisplayAlert("Erro", "Telefone ou senha inválidos.", "Ok");
                            }
                            catch (ArgumentException)
                            {
                                IsWaiting = false;
                                await Message.DisplayAlert("Erro", "Já existe um usuário cadastrado com este telefone.", "Ok");
                            }
                            catch (Exception)
                            {
                                IsWaiting = false;
                                await Message.DisplayAlert("Erro", "Não foi possível conectar-se ao servidor, tente novamente em breve.", "Ok");
                            }
                        }
                        else
                        {
                            await Message.DisplayAlert("Atenção", sbError.ToString(), "Ok");
                        }
                    });
                }));
            }
        }
        #endregion
    }
}
