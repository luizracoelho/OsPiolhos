using Piolhos.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class EventosController : ApiController
    {
        EventoLogic _logic;

        public EventosController()
        {
            _logic = new EventoLogic();
        }

        [HttpGet]
        public async Task<IEnumerable<Evento>> Get() => await _logic.ListAsync();
    }
}
