using Piolhos.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piolhos.Logic
{
    public class EventoLogic
    {
        EventoRepository _repository;

        public EventoLogic()
        {
            _repository = new EventoRepository();
        }

        public async Task<IEnumerable<Evento>> ListAsync() => await _repository.GetAllAsync();
    }
}
