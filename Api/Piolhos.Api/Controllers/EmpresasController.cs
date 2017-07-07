using Piolhos.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class EmpresasController : ApiController
    {
        EmpresaLogic _logic;

        public EmpresasController()
        {
            _logic = new EmpresaLogic();
        }

        // GET: api/Empresas/Latitude/Longitude
        [HttpGet, Route("api/empresas/{lat}/{lng}")]
        public async Task<IEnumerable<Empresa>> Get(double lat, double lng)
        {
            //Recuperar as empresas
            var empresas = await _logic.ListAsync(lat, lng);

            //Retornar as empresas
            return empresas;
        }
    }
}
