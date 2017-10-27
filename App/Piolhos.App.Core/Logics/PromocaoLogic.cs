using Piolhos.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piolhos.App.Core.Logics
{
    public class PromocaoLogic
    {
        PromocaoService _service;

        public PromocaoLogic()
        {
            _service = new PromocaoService();
        }

        public async Task<IList<Promocao>> ListAsync() => await _service.ListAsync($"promocoes/");
    }
}
