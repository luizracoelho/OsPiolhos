using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using Piolhos.App.Views;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class AlteracaoCadastroViewModel : EntityViewModel<Usuario>
    {
        UsuarioLogic _usuarioLogic;
        LoginLogic _loginLogic;

        public AlteracaoCadastroViewModel()
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

                    IsWaiting = false;
                }
                catch (Exception)
                {
                    IsWaiting = false;
                    await Message.DisplayAlert("Erro", "Não foi possível conectar-se ao servidor, tente novamente em breve.", "Ok");
                }
            });
        }

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
                        var hasError = false;
                        var sbError = new StringBuilder();

                        sbError.Append("Os campos abaixo são obrigatórios:\n");

                        if (string.IsNullOrEmpty(Model.Nome))
                        {
                            hasError = true;
                            sbError.Append(" - Nome\n");
                        }

                        if (string.IsNullOrEmpty(Model.Email))
                        {
                            hasError = true;
                            sbError.Append(" - E-Mail\n");
                        }

                        if (string.IsNullOrEmpty(Model.Telefone))
                        {
                            hasError = true;
                            sbError.Append(" - Telefone\n");
                        }

                        if (!hasError)
                        {
                            try
                            {
                                //Validar o e-mail
                                var rgx = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                                if (!rgx.IsMatch(Model.Email))
                                    throw new FormatException("E-Mail");

                                IsWaiting = true;

                                //Cadastrar o usuário
                                if (await _usuarioLogic.SaveAsync(Model))
                                {
                                    //Preencher o login
                                    var login = _loginLogic.Get();
                                    login.Telefone = Model.Telefone;

                                    //Efetuar o login
                                    if (await _loginLogic.LoginAsync(login))
                                        App.Current.MainPage = new RootPage();
                                    else
                                        throw new ArgumentNullException();
                                }
                                else
                                    throw new ArgumentException();
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
                            catch (FormatException)
                            {
                                IsWaiting = false;
                                await Message.DisplayAlert("Atenção", "E-mail inválido.", "Ok");
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
