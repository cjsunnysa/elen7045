using System;
using FaultLogging.Core.Interfaces;

namespace FaultLogging.Core.Model
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; private set; }
        public string CrossStreet { get; private set; }
        public string Suburb { get; private set; }
        public string PostCode { get; private set; }

        public Address(string street, string crossStreet, string suburb, string postCode)
        {
            Street = street;
            CrossStreet = crossStreet;
            Suburb = suburb;
            PostCode = postCode;
        }
    }
}