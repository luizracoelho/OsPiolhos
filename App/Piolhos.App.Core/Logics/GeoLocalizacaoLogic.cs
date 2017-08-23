using Piolhos.App.Core.DataAccess;

namespace Piolhos.App.Core.Logics
{
    public class GeoLocalizacaoLogic
    {
        GeoLocalizacaoDataAccess _data;

        public GeoLocalizacaoLogic()
        {
            _data = new GeoLocalizacaoDataAccess();
        }

        public GeoLocalizacao Get()
        {
            return _data.Get();
        }

        public void Save(GeoLocalizacao geoLocalizacao)
        {
            if (geoLocalizacao != null)
                _data.Save(geoLocalizacao);
        }
    }
}
