using Piolhos.App.Core.DataAccess;
using Piolhos.App.Core.Services;
using System.Threading.Tasks;

namespace Piolhos.App.Core.Logics
{
    public class LoginLogic
    {
        LoginService _service;
        LoginDataAccess _data;

        public LoginLogic()
        {
            _service = new LoginService();
            _data = new LoginDataAccess();
        }

        public Login Get()
        {
            return _data.Get();
        }

        public async Task<bool> LoginAsync(Login login)
        {
            var retorno = await _service.PostWithReturnBooleanAsync("login", login);

            if (retorno)
                _data.Save(login);

            return retorno;
        }

        public void Logout()
        {
            var login = Get();

            if (login != null)
                _data.Delete(login);
        }
    }
}
