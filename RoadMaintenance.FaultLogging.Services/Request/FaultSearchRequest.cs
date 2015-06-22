using System;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.DTO
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