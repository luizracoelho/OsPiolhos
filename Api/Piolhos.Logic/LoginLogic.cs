using Piolhos.Logic.Tools;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Piolhos.Logic
{
    public class LoginLogic
    {
        UsuarioLogic _logic;
        Crypt _crypt;

        public LoginLogic()
        {
            _logic = new UsuarioLogic();
            _crypt = new Crypt();
        }

        public async Task<bool> LoginAsync(Login login)
        {
            login.Telefone = string.Join("", Regex.Split(login.Telefone, @"[^\d]"));
            login.Senha = _crypt.Encrypt(login.Senha);

            var usuario = await _logic.GetByLoginAsync(login);

            if (usuario == null)
                return false;

            return true;
        }
    }
}
