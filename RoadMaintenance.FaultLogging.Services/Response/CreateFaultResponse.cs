using System;
using RoadMaintenance.FaultLogging.Core.Enums;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Response
{
    public class CreateFaultResponse
    {
        public Guid Id { get; private set; }
        public string StreetName { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }
        public Status Status { get; private set; }
        public Type Type { get; private set; }
        public string ReferenceNumber { get; private set; }

        public CreateFaultResponse(
            Guid id,
            string streetName,
            string crossStreet,
            string suburb,
            string postCode,
            Status status,
            Type type,
            string referenceNumber)
        {
            Id = id;
            StreetName = streetName;
            CrossStreet = crossStreet;
            Suburb = suburb;
            PostCode = postCode;
            Status = status;
            Type = type;
            ReferenceNumber = referenceNumber;
        }
    }
}