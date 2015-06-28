using System;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Request
{
    public class CreateFaultRequest
    {
        public string StreetName { get; set; }
        public string CrossStreet { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }

        public CreateFaultRequest(string street1, string street2, string suburb, string postCode, Type type, string description)
        {
            StreetName = street1;
            CrossStreet = street2;
            Suburb = suburb;
            PostCode = postCode;
            Type = type;
            Description = description;
        }
    }
}