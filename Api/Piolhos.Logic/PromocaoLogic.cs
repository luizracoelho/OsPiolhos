using Piolhos.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piolhos.Logic
{
    public class PromocaoLogic
    {
        PromocaoRepository _repository;

        public PromocaoLogic()
        {
            _repository = new PromocaoRepository();
        }

        public async Task<IEnumerable<Promocao>> ListAsync()=> await _repository.GetAllAsync();
    }
}
