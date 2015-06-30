using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using RoadMaintenance.SharedKernel.Repos;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Repos.Interfaces
{
    public interface IFaultRepository : IRepository<Guid, Fault>
    {
        IEnumerable<Fault> SearchForRecentFaults(
            string street1,
            string street2, 
            string suburb, 
            Type? type, 
            DateTime? repairedPeriod);
    }
}