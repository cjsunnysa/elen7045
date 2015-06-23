using System;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Request
{
    public class CreateFaultRequest
    {
        public string StreetName { get; set; }
        public string CrossStreet { get; set; }
        public string Suburb { get; set; }
        public Type Type { get; set; }
        public int OperatorId { get; set; }
        public DateTime CurrentDateTime { get; set; }


        public CreateFaultRequest(string street1, string street2, string suburb, Type type, int operatorId, DateTime currentDateTime)
        {
            StreetName = street1;
            CrossStreet = street2;
            Suburb = suburb;
            Type = type;
            OperatorId = operatorId;
            CurrentDateTime = currentDateTime;
        }
    }
}