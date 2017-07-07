using Piolhos.Base;

namespace Piolhos
{
    public class Empresa : BaseEntity
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                RaisedPropertyChanged(() => Nome);
            }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                _descricao = value;
                RaisedPropertyChanged(() => Descricao);
            }
        }

        private string _categoria;
        public string Categoria
        {
            get { return _categoria; }
            set
            {
                _categoria = value;
                RaisedPropertyChanged(() => Categoria);
            }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                RaisedPropertyChanged(() => Latitude);
            }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                RaisedPropertyChanged(() => Longitude);
            }
        }

        private double _distancia;
        public double Distancia
        {
            get { return _distancia; }
            set
            {
                _distancia = value;
                RaisedPropertyChanged(() => Distancia);
            }
        }

        private string _distanciaString;
        public string DistanciaString
        {
            get { return _distanciaString; }
            set
            {
                _distanciaString = value;
                RaisedPropertyChanged(() => DistanciaString);
            }
        }

        private string _slogan;
        public string Slogan
        {
            get { return _slogan; }
            set
            {
                _slogan = value;
                RaisedPropertyChanged(() => Slogan);
            }
        }

        private string _telefone;
        public string Telefone
        {
            get { return _telefone; }
            set
            {
                _telefone = value;
                RaisedPropertyChanged(() => Telefone);
            }
        }

        private string _site;
        public string Site
        {
            get { return _site; }
            set
            {
                _site = value;
                RaisedPropertyChanged(() => Site);
            }
        }

        private string _facebook;
        public string Facebook
        {
            get { return _facebook; }
            set
            {
                _facebook = value;
                RaisedPropertyChanged(() => Facebook);
            }
        }

        private string _endereco;
        public string Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value;
                RaisedPropertyChanged(() => Endereco);
            }
        }

        private string _beneficio1;
        public string Beneficio1
        {
            get { return _beneficio1; }
            set
            {
                _beneficio1 = value;
                RaisedPropertyChanged(() => Beneficio1);
            }
        }

        private string _beneficio2;
        public string Beneficio2
        {
            get { return _beneficio2; }
            set
            {
                _beneficio2 = value;
                RaisedPropertyChanged(() => Beneficio2);
            }
        }

        private string _beneficio3;
        public string Beneficio3
        {
            get { return _beneficio3; }
            set
            {
                _beneficio3 = value;
                RaisedPropertyChanged(() => Beneficio3);
            }
        }

        private int _quantAvaliacoes;
        public int QuantAvaliacoes
        {
            get { return _quantAvaliacoes; }
            set
            {
                _quantAvaliacoes = value;
                RaisedPropertyChanged(() => QuantAvaliacoes);
            }
        }

        private double _valorAvaliacoes;
        public double ValorAvaliacoes
        {
            get { return _valorAvaliacoes; }
            set
            {
                _valorAvaliacoes = value;
                RaisedPropertyChanged(() => ValorAvaliacoes);
            }
        }

        private string _logo;
        public string Logo
        {
            get { return _logo; }
            set
            {
                _logo = value;
                RaisedPropertyChanged(() => Logo);
            }
        }

        private string _imagem;
        public string Imagem
        {
            get { return _imagem; }
            set
            {
                _imagem = value;
                RaisedPropertyChanged(() => Imagem);
            }
        }
    }
}
