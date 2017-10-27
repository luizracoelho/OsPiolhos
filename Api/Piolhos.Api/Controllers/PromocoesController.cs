using Piolhos.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class PromocoesController : ApiController
    {
        PromocaoLogic _logic;

        public PromocoesController()
        {
            _logic = new PromocaoLogic();
        }

        [HttpGet]
        public async Task<IEnumerable<Promocao>> Get() => await _logic.ListAsync();
    }
}
