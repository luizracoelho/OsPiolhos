using Piolhos.Base;
using System;

namespace Piolhos
{
    public abstract class Informacao : BaseEntity
    {
        private DateTime _dataHora;
        public DateTime DataHora
        {
            get { return _dataHora; }
            set
            {
                _dataHora = value;
                RaisedPropertyChanged(() => DataHora);
            }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                RaisedPropertyChanged(() => Titulo);
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
