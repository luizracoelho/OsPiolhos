using Piolhos.Base;

namespace Piolhos
{
    public class GeoLocalizacao : BaseEntity
    {
        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                RaisedPropertyChanged(() => Latitude);
            }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                RaisedPropertyChanged(() => Longitude);
            }
        }
    }
}
