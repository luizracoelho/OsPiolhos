using Piolhos.Base;

namespace Piolhos
{
    public class Login : BaseEntity
    {
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
    }
}
