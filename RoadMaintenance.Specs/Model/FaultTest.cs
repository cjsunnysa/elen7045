using System;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public class FaultTest
    {
        public Guid Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Street { get; set; }
        public string CrossStreet { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Description { get; set; }
    }
}
