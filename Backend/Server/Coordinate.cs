using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    class Coordinate {

        double Latitude;
        double Longitude;

        public Coordinate(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double GetLatitude() {
            return Latitude;
        }

        public double GetLongitude() {
            return Longitude;
        }
    }
}
