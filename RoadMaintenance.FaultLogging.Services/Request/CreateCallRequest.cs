using System;

namespace RoadMaintenance.FaultLogging.Services.Request
{
    public class CreateCallRequest
    {
        public Guid FaultId { get; set; }
        public int OperatorId { get; set; }
        public DateTime CallDateTime { get; set; }
    }
}