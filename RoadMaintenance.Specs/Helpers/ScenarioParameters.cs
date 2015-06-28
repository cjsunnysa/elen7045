using System;
using System.Collections.Generic;
using Ninject;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Services.Interfaces;
using RoadMaintenance.FaultLogging.Services.Response;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public class ScenarioParameters
    {
        public string GivenFaultId { get; set; }
        public Core.Enums.Type? Type { get; set; }
        public string Description { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public DateTime? RepairedPeriodStartDate { get; set; }
        public DateTime? TodayDate { get; set; }

        public IFaultService FaultService { get; set; }
        public IEnumerable<FaultDetailsView> ResultsCollection { get; set; }
        public bool InvalidOperationThrown { get; set; }
        public bool ArgumentExceptionThrown { get; set; }
        public string CallReferenceNumber { get; set; }
        public Priority Priority { get; set; }
    }
}