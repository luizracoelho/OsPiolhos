using Piolhos.Logic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class LoginController : ApiController
    {
        LoginLogic _logic;

        public LoginController()
        {
            _logic = new LoginLogic();
        }

        // POST: api/Login
        public async Task<bool> Post(Login login)
        {
            return await _logic.LoginAsync(login);
        }
    }
}
