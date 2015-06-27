using RoadMaintenance.Common;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }

        private Address(string street, string crossStreet, string suburb, string postCode)
        {
            Guard.ForNullOrEmpty(street, "street");
            Guard.ForNullOrEmpty(suburb, "suburb");

            Street = street;
            CrossStreet = crossStreet;
            Suburb = suburb;
            PostCode = postCode;
        }

        internal static Address Create(string street, string crossStreet, string suburb, string postCode)
        {
            return new Address(street, crossStreet, suburb, postCode);
        }
    }
}