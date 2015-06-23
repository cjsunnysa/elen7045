using System;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Response
{
    public class FaultSearchResponse : IEquatable<FaultSearchResponse>
    {
        public Guid Id { get; private set; }
        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public string Longitude { get; private set; }
        public string Latitude { get; private set; }
        public string StreetName { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }
        public DateTime? EstimatedCompletionDate { get; private set; }
        public DateTime? DateCompleted { get; private set; }

        public FaultSearchResponse(Guid id,Type type,Status status, Location location, DateTime? estCompletionDate, DateTime? dateCompleted)
        {
            Id = id;
            Type = type;
            Status = status;
            Longitude = location.GpsCoordinates == null
                        ? null
                        : location.GpsCoordinates.Longitude;
            Latitude = location.GpsCoordinates == null
                       ? null
                       : location.GpsCoordinates.Latitude;
            StreetName = location.Address.Street;
            CrossStreet = location.Address.CrossStreet;
            Suburb = location.Address.Suburb;
            PostCode = location.Address.PostCode;
            EstimatedCompletionDate = estCompletionDate;
            DateCompleted = dateCompleted;
        }

        public bool Equals(FaultSearchResponse other)
        {
            return
                Id.Equals(other.Id) &&
                Type.Equals(other.Type) &&
                Status.Equals(other.Status) &&
                Longitude == null ? other.Longitude == null : Longitude.Equals(other.Longitude) &&
                Latitude == null ? other.Latitude == null : Latitude.Equals(other.Latitude) &&
                StreetName.Equals(other.StreetName) &&
                CrossStreet.Equals(other.CrossStreet) &&
                Suburb.Equals(other.Suburb) &&
                PostCode.Equals(other.PostCode) &&
                EstimatedCompletionDate.Equals(other.EstimatedCompletionDate) &&
                DateCompleted.Equals(other.DateCompleted);
        }
    }
}