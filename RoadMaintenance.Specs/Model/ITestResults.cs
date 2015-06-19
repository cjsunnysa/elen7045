using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultLogging.Core.Model;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public interface ITestResults
    {
        IEnumerable<Fault> Results { get; set; }
    }
}
