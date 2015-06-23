using System;

namespace RoadMaintenance.FaultLogging.Services.Request
{
    public class UpdateAddressRequest
    {
        public Guid FaultId { get; private set; }
        public string StreetName { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }

        public UpdateAddressRequest(Guid faultId, string streetName, string crossStreet, string suburb, string postCode)
        {
            FaultId = faultId;
            StreetName = streetName;
            CrossStreet = crossStreet;
            Suburb = suburb;
            PostCode = postCode;
        }
    }
}