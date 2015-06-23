using System;
using System.Text.RegularExpressions;
using RoadMaintenance.ApplicationLayer;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class GPSCoordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        private GPSCoordinates(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static GPSCoordinates Create(string latitude, string longitude)
        {
            Guard.ForNullOrEmpty(latitude, "latitude");
            Guard.ForNullOrEmpty(longitude, "longitude");

            var regEx = new Regex(@"^([0-9]{2}[^\w\d][0-9]{2}[^\w\d][0-9]{2}[^\w\d][nNsS])");
            
            if (!regEx.IsMatch(latitude))
                throw new FormatException("latitude must match format degrees-minutes-seconds-hemisphere\ndd-dd-dd-N\ndd dd dd S\ndd/dd/dd/N");

            if (!regEx.IsMatch(longitude))
                throw new FormatException("longitude must match format degrees-minutes-seconds-east\\west\ndd-dd-dd-E\ndd dd dd W\ndd/dd/dd/W");

            var repRegEx = new Regex(@"[^\w\d]");
            var formattedLat = repRegEx.Replace(latitude, @"\s");
            var formattedLong = repRegEx.Replace(longitude, @"\s");
            
            return new GPSCoordinates(formattedLat, formattedLong);
        }
    }
}