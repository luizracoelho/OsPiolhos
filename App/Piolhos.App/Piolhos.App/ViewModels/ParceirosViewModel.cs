using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using Piolhos.App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class ParceirosViewModel : ListViewModel<Empresa>
    {
        EmpresaLogic _logic;
        IList<Empresa> _empresasFiltered;

        public ParceirosViewModel()
        {
            _logic = new EmpresaLogic();

            List();
        }

        void List(string search = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsRefreshing = true;

                    IList<Empresa> empresas = new List<Empresa>();
                    if (search == null)
                    {
                        //Recuperar as empresas
                        empresas = await _logic.ListAsync();
                        _empresasFiltered = empresas;
                    }
                    else
                    {
                        //Filtrar as empresas
                        empresas = _empresasFiltered
                                    .Where(x =>
                                        x.Nome.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                                        x.Slogan.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                                        x.Categoria.Trim().ToLower().Contains(search.Trim().ToLower())
                                    )
                                    .ToList();
                    }

                    //Definir o logo caso não exista
                    foreach (var empresa in empresas)
                        empresa.Logo = empresa.Logo ?? "logo.png";

                    Model = new ObservableCollection<Empresa>(empresas);

                    ErrorMessage = empresas.Count == 0 ? "Nenhum parceiro encontrado." : null;

                    IsRefreshing = false;
                }
                catch (Exception)
                {
                    Model = null;
                    IsRefreshing = false;
                    ErrorMessage = "Não foi possível conectar-se ao servidor, tente novamente em breve.";
                }
            });
        }

        public override void ItemTapped()
        {
            base.ItemTapped();

            try
            {
                IsWaiting = true;

                var empresa = Item;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    IsWaiting = false;
                    await Navigation.PushAsync(new ParceiroPage(empresa));
                });
            }
            catch (Exception)
            {
                IsWaiting = false;
                ErrorMessage = "Não foi possível obter a empresa.";
            }
        }

        #region Properties
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                RaisedPropertyChanged(() => Search);

                List(_search);
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                _errorIsVisible = _errorMessage != null;
                RaisedPropertyChanged(() => ErrorMessage);
                RaisedPropertyChanged(() => ErrorIsVisible);
            }
        }

        private bool _errorIsVisible;
        public bool ErrorIsVisible
        {
            get { return _errorIsVisible; }
            set
            {
                _errorIsVisible = value;
                RaisedPropertyChanged(() => ErrorIsVisible);
            }
        }
        #endregion

        #region Commands
        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new Command(() =>
                {
                    Search = null;
                    List();
                }));
            }
        }
        #endregion
    }
}
