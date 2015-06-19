using System.Collections.Generic;
using Ninject;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Model;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public class StepParameters
    {
        public StandardKernel Kernel { get; set; }
        public string GivenFaultId { get; set; }
        public FaultSearchRequest GivenSearchRequest { get; set; }
        public IEnumerable<Fault> GivenCollection { get; set; }
        public IEnumerable<Fault> ResultsCollection { get; set; }
    }
}