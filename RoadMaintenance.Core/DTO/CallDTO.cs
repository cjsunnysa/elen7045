using System;

namespace RoadMaintenance.FaultLogging.Core.DTO
{
    public class CallDTO
    {
        public string ReferenceNumber { get; set; }
        public int OperatorId { get; set; }
        public DateTime CallDate { get; set; }
    }
}