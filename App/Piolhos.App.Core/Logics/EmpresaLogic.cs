using Piolhos.App.Core.Services;
using Plugin.Geolocator;
using System;
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

        public async Task<IList<Empresa>> ListAsync()
        {
            //Obter a última GeoLocalização
            var geoLocalizacaoBo = new GeoLocalizacaoLogic();
            var geoLocalizacao = geoLocalizacaoBo.Get();

            try
            {
                //Recuperar a geolocalização
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync(10000);

                //Salvar a posição atual
                if (geoLocalizacao == null)
                    geoLocalizacao = new GeoLocalizacao();

                geoLocalizacao.Latitude = position.Latitude;
                geoLocalizacao.Longitude = position.Longitude;
                geoLocalizacaoBo.Save(geoLocalizacao);
            }
            catch (Exception)
            {
                // Caso não consiga a posição do GPS e nem uma última geolocalização, passa-se o marco zero de Ribeirão Preto como padrão
                if (geoLocalizacao == null)
                    geoLocalizacao = new GeoLocalizacao
                    {
                        Latitude = -21.174587700091447,
                        Longitude = -47.80945301055908
                    };
            }

            //Trocar vírgulas por pontos
            var latStr = geoLocalizacao.Latitude.ToString().Replace(",", ".");
            var lngStr = geoLocalizacao.Longitude.ToString().Replace(",", ".");

            //Fazer a requisição
            return await _service.ListAsync($"empresas/{latStr}/{lngStr}");
        }
    }
}
