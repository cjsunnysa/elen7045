using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultVerification.Services
{
    public class Jurisdiction
    {
        private string longitude;
        private string latitude;
        private int radius;

        public Jurisdiction(string longitude, string latitude, int radius)
        {
            // TODO: Complete member initialization
            this.longitude = longitude;
            this.latitude = latitude;
            this.radius = radius;
        }
    }
}
