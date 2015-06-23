using System;

namespace RoadMaintenance.FaultLogging.Services.Response
{
    public class UpdateGpsCoordinatesResponse
    {
        public Guid FaultId { get; private set; }
        public string Longitude { get; private set; }
        public string Latitude { get; private set; }

        public UpdateGpsCoordinatesResponse(Guid faultId, string longitude, string latitude)
        {
            FaultId = faultId;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}