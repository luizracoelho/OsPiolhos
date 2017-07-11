using Piolhos.Logic;
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

        [HttpPost]
        public bool Post(Notificacao notificacao)
        {
            return _logic.Notificar(notificacao);
        }
    }
}
