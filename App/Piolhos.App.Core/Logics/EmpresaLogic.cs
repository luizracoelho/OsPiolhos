using Piolhos.App.Core.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Piolhos.App.Core.Logics
{
    public class EmpresaLogic
    {
        EmpresaService _service;

        public EmpresaLogic()
        {
            _service = new EmpresaService();
        }

        public async Task<IList<Empresa>> ListAsync(double? lat, double? lng)
        {
            // Caso não consiga a posição do GPS, passa-se o marco zero de Ribeirão Preto como padrão
            lat = lat ?? -21.174587700091447;
            lng = lng ?? -47.80945301055908;

            var latStr = lat.ToString().Replace(",", ".");
            var lngStr = lng.ToString().Replace(",", ".");

            //Fazer a requisição
            return await _service.ListAsync($"empresas/{latStr}/{lngStr}");
        }
    }
}
