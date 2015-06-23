using System.Net.NetworkInformation;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Location
    {
        public GPSCoordinates GpsCoordinates { get; private set; }
        public Address Address { get; private set; }

        private Location(GPSCoordinates gps, Address address)
        {
            GpsCoordinates = gps;
            Address = address;
        }

        public static Location Create(Address address)
        {
            return new Location(null, address);
        }

        public static Location Create(GPSCoordinates gps, Address address)
        {
            return new Location(gps, address);
        }
    }
}