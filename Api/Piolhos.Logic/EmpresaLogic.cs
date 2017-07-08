using Piolhos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piolhos.Logic
{
    public class EmpresaLogic
    {
        EmpresaRepository _repository;

        public EmpresaLogic()
        {
            _repository = new EmpresaRepository();
        }

        public async Task<IEnumerable<Empresa>> ListAsync(double lat, double lng)
        {
            var empresas = await _repository.GetAllAsync();

            foreach (var empresa in empresas)
            {
                //Calcular a Distância
                empresa.Distancia = CalcularDistancia(lat, lng, empresa.Latitude, empresa.Longitude);

                //Preencher a mensagem
                if (empresa.Distancia < 1)
                    empresa.DistanciaString = $"{(empresa.Distancia * 1000).ToString("N0")}m";
                else
                    empresa.DistanciaString = $"{empresa.Distancia.ToString("N2")}km";
            }

            return empresas.OrderBy(x => x.Distancia);
        }

        private double CalcularDistancia(double origem_lat, double origem_lng, double destino_lat, double destino_lng)
        {
            double x1 = origem_lat;
            double x2 = destino_lat;
            double y1 = origem_lng;
            double y2 = destino_lng;

            // Distancia entre os 2 pontos no plano cartesiano ( pitagoras )
            // distancia = System.Math.Sqrt( System.Math.Pow( (x2 - x1), 2 ) + System.Math.Pow( (y2 - y1), 2 ) );

            // ARCO AB = c 
            double c = 90 - (y2);

            // ARCO AC = b 
            double b = 90 - (y1);

            // Arco ABC = a 
            // Diferença das longitudes: 
            double a = x2 - x1;

            // Formula: cos(a) = cos(b) * cos(c) + sen(b)* sen(c) * cos(A) 
            double cos_a = Math.Cos(b) * Math.Cos(c) + Math.Sin(c) * Math.Sin(b) * Math.Cos(a);

            double arc_cos = Math.Acos(cos_a);

            // 2 * pi * Raio da Terra = 6,28 * 6.371 = 40.030 Km 
            // 360 graus = 40.030 Km 
            // 3,2169287 = x 
            // x = (40.030 * 3,2169287)/360 = 357,68 Km 

            double distancia = (40030 * arc_cos) / 360;

            return distancia;
        }
    }
}
