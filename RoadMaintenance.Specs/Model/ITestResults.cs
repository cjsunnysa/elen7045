using System.Collections.Generic;
using RoadMaintenance.FaultLogging.Core.Model;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public interface ITestResults
    {
        IEnumerable<Fault> Results { get; set; }
    }
}
