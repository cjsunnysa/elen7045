using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultVerification.Specs.Model
{
    public class FaultTestData
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string CrossStreet { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

        public FaultTestData()
        {
        }
    }
}
