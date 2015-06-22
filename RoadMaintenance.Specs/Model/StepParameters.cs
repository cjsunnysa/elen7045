using System.Collections.Generic;
using Ninject;
using RoadMaintenance.FaultLogging.Services.DTO;
using RoadMaintenance.FaultLogging.Services.Response;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public class StepParameters
    {
        public StandardKernel Kernel { get; set; }
        public string GivenFaultId { get; set; }
        public FaultSearchRequest GivenSearchRequest { get; set; }
        public IEnumerable<FaultSearchResponse> GivenCollection { get; set; }
        public IEnumerable<FaultSearchResponse> ResultsCollection { get; set; }
    }
}