using Piolhos.Logic;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class NotificacaoController : ApiController
    {
        NotificacaoLogic _logic;

        public NotificacaoController()
        {
            _logic = new NotificacaoLogic();
        }

        [HttpGet, Route("api/notificacao/{api_key}/{title}/{message}")]
        public bool Get(string api_key, string title, string message)
        {
            return _logic.Notificar(api_key, title, message);
        }
    }
}
