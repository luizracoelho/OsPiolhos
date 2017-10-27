using Piolhos.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piolhos.App.Core.Logics
{
    public class EventoLogic
    {
        EventoService _service;

        public EventoLogic()
        {
            _service = new EventoService();
        }

        public async Task<IList<Evento>> ListAsync() => await _service.ListAsync($"eventos/");
    }
}
