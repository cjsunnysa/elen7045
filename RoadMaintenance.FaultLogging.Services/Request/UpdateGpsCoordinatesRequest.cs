using System;

namespace RoadMaintenance.FaultLogging.Services.Request
{
    public class UpdateGpsCoordinatesRequest
    {
        public Guid FaultId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}