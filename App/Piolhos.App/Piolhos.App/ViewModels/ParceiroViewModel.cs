using Piolhos.App.ViewModels.Base;
using Plugin.ExternalMaps;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Piolhos.App.ViewModels
{
    public class ParceiroViewModel : EntityViewModel<Empresa>
    {
        private string GetUrl(string url)
        {
            var rgx = new Regex(@"(http)(s{0,})(://)?");
            var preffix = rgx.IsMatch(url) ? "" : "http://";

            return preffix + url;
        }

        #region Properties
        public bool SloganIsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Slogan); }
        }

        public bool TelefoneIsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Telefone); }
        }

        public bool SiteIsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Site); }
        }

        public bool FacebookIsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Facebook); }
        }

        public bool EnderecoIsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Endereco); }
        }

        public bool DescricaoIsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Descricao); }
        }

        public bool Beneficio1IsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Beneficio1); }
        }

        public bool Beneficio2IsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Beneficio2); }
        }

        public bool Beneficio3IsVisible
        {
            get { return !string.IsNullOrEmpty(Model.Beneficio3); }
        }

        public bool BeneficiosIsVisible
        {
            get { return Beneficio1IsVisible || Beneficio2IsVisible || Beneficio3IsVisible; }
        }

        public double ValorAvaliacoes
        {
            get
            {
                return Model.ValorAvaliacoes;
            }
        }

        public string MsgAvaliacoes
        {
            get
            {
                var aval = Model.QuantAvaliacoes == 1 ? "avaliação" : "avaliações";
                return $"Baseado em { Model.QuantAvaliacoes } {aval}.";
            }
        }
        #endregion

        #region Commands
        private ICommand _telefoneCommand;
        public ICommand TelefoneCommand
        {
            get
            {
                return _telefoneCommand ?? (_telefoneCommand = new Command(() =>
                {
                    Device.OpenUri(new Uri($"tel:{Model.Telefone}"));
                }));
            }
        }

        private ICommand _siteCommand;
        public ICommand SiteCommand
        {
            get
            {
                return _siteCommand ?? (_siteCommand = new Command(() =>
                {
                    Device.OpenUri(new Uri(GetUrl(Model.Site)));
                }));
            }
        }

        private ICommand _facebookCommand;
        public ICommand FacebookCommand
        {
            get
            {
                return _facebookCommand ?? (_facebookCommand = new Command(() =>
                {
                    Device.OpenUri(new Uri(GetUrl(Model.Facebook)));
                }));
            }
        }

        private ICommand _enderecoCommand;
        public ICommand EnderecoCommand
        {
            get
            {
                return _enderecoCommand ?? (_enderecoCommand = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var success = await CrossExternalMaps.Current.NavigateTo(Model.Nome, Model.Latitude, Model.Longitude);
                    });
                }));
            }
        }
        #endregion
    }
}
