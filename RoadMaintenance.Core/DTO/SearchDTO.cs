using System;
using RoadMaintenance.FaultLogging.Core.Enums;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Core.DTO
{
    public class FaultSearchRequest
    {
        public Type? Type { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Suburb { get; set; }
        public DateTime? RepairedPeriodStartDate { get; set; }
        public DateTime? TodayDate { get; set; }
    }
}