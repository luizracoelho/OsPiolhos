using Piolhos.Base;
using System;

namespace Piolhos
{
    public class Usuario : BaseEntity
    {
        private string _nome;
        public string Nome {
            get { return _nome; }
            set {
                _nome = value;
                RaisedPropertyChanged(() => Nome);
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisedPropertyChanged(() => Email);
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

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                RaisedPropertyChanged(() => Senha);
            }
        }

        private DateTime _dataCadastro;
        public DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set
            {
                _dataCadastro = value;
                RaisedPropertyChanged(() => DataCadastro);
            }
        }
    }
}
