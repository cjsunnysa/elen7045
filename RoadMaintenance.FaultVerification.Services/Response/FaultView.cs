using RoadMaintenance.FaultVerification.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = RoadMaintenance.FaultVerification.Core.Enums.Type;

namespace RoadMaintenance.FaultVerification.Services.Response
{
    public class FaultView : IEquatable<FaultView>
    {
        public Guid Id { get; private set; }
        public string StreetName { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }
        public string Longitude { get; private set; }
        public string Latitude { get; private set; }
        public Status Status { get; private set; }
        public Type Type { get; private set; }
        public int Priority { get; set; }
        public int Distance { get; set; }

        public FaultView(Guid id, string street, string crossStreet, string suburb, string postCode, string longitude, string latitude, Status status, Type type, int priority, int distance)
        {
            Id = id;
            StreetName = street;
            CrossStreet = crossStreet;
            Suburb = suburb;
            PostCode = postCode;
            Longitude = longitude;
            Latitude = latitude;
            Status = status;
            Type = type;
            Priority = priority;
            Distance = distance;
           
        }

        public bool Equals(FaultView other)
        {
            return
                Id.Equals(other.Id) &&
                Type.Equals(other.Type) &&
                Status.Equals(other.Status) &&
                StreetName.Equals(other.StreetName, StringComparison.CurrentCultureIgnoreCase) &&
                Suburb.Equals(other.Suburb, StringComparison.CurrentCultureIgnoreCase) &&
                (Longitude == null                 ? other.Longitude == null                 : Longitude.Equals(other.Longitude) ) &&
                (Latitude == null                  ? other.Latitude == null                  : Latitude.Equals(other.Latitude) ) &&
                (string.IsNullOrEmpty(CrossStreet) ? string.IsNullOrEmpty(other.CrossStreet) : CrossStreet.Equals(other.CrossStreet, StringComparison.CurrentCultureIgnoreCase) ) &&
                (string.IsNullOrEmpty(PostCode)    ? string.IsNullOrEmpty(other.PostCode)    : PostCode.Equals(other.PostCode, StringComparison.CurrentCultureIgnoreCase) );
        }
    }
}
