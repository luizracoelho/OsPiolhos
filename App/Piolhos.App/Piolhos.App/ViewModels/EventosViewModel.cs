using Piolhos.App.Core.Logics;
using Piolhos.App.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class EventosViewModel : ListViewModel<Evento>
    {
        EventoLogic _logic;
        IList<Evento> _promocoesFiltered;

        public EventosViewModel()
        {
            _logic = new EventoLogic();

            List();
        }

        void List(string search = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsRefreshing = true;

                    IList<Evento> promocoes = new List<Evento>();
                    if (search == null)
                    {
                        //Recuperar as promocoes
                        promocoes = await _logic.ListAsync();
                        _promocoesFiltered = promocoes;
                    }
                    else
                    {
                        //Filtrar as promocoes
                        promocoes = _promocoesFiltered
                                    .Where(x =>
                                        x.Titulo.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                                        x.Descricao.Trim().ToLower().Contains(search.Trim().ToLower())
                                    )
                                    .ToList();
                    }

                    Model = new ObservableCollection<Evento>(promocoes);

                    ErrorMessage = promocoes.Count == 0 ? "Nenhum evento disponível." : null;

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
