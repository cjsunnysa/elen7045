using System;

namespace RoadMaintenance.FaultLogging.Core.DTO
{
    public class FaultSearchRequest
    {
        public int? TypeId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Suburb { get; set; }
        public DateTime? RepairedPeriodStartDate { get; set; }
    }
}
