using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class DataPoint
    {
        double _lat, _lon;

        public DataPoint(double lat, double lon)
        {
            _lat = lat;
            _lon = lon;
        }

        public double GetLat()
        {
            return _lat;
        }

        public double GetLon()
        {
            return _lon;
        }

    }
}
