using System;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Response
{
    public class FaultDetailsView : IEquatable<FaultDetailsView>
    {
        public Guid Id { get; private set; }
        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public string Description { get; set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string StreetName { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }
        public DateTime? EstimatedCompletionDate { get; private set; }
        public DateTime? DateCompleted { get; private set; }

        public FaultDetailsView(Guid id,Type type,Status status, string description, DateTime? estCompletionDate, DateTime? dateCompleted, string street, string crossStreet, string suburb, string postCode, string latitude, string longitude)
        {
            Id = id;
            Type = type;
            Status = status;
            Description = description;
            Longitude = longitude;
            Latitude  = latitude;
            StreetName = street;
            CrossStreet = crossStreet;
            Suburb = suburb;
            PostCode = postCode;
            EstimatedCompletionDate = estCompletionDate;
            DateCompleted = dateCompleted;
        }

        public bool Equals(FaultDetailsView other)
        {
            return
                Id.Equals(other.Id) &&
                Type.Equals(other.Type) &&
                Status.Equals(other.Status) &&
                StreetName.Equals(other.StreetName, StringComparison.CurrentCultureIgnoreCase) &&
                Suburb.Equals(other.Suburb, StringComparison.CurrentCultureIgnoreCase) &&
                (Longitude == null                 ? other.Longitude == null                 : Longitude.Equals(other.Longitude) ) &&
                (Latitude == null                  ? other.Latitude == null                  : Latitude.Equals(other.Latitude) ) &&
                (DateCompleted == null             ? other.DateCompleted == null             : DateCompleted.Equals(other.DateCompleted) ) &&
                (EstimatedCompletionDate == null   ? other.EstimatedCompletionDate == null   : EstimatedCompletionDate.Equals(other.EstimatedCompletionDate) ) &&
                (string.IsNullOrEmpty(CrossStreet) ? string.IsNullOrEmpty(other.CrossStreet) : CrossStreet.Equals(other.CrossStreet, StringComparison.CurrentCultureIgnoreCase) ) &&
                (string.IsNullOrEmpty(PostCode)    ? string.IsNullOrEmpty(other.PostCode)    : PostCode.Equals(other.PostCode, StringComparison.CurrentCultureIgnoreCase) );
        }
    }
}