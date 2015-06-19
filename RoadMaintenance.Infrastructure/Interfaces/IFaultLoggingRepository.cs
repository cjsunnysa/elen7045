using System;
using System.Collections.Generic;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Repos.Interfaces
{
    public interface IFaultLoggingRepository : IRepository<Fault, Guid>
    {
        IEnumerable<Fault> Find(FaultSearchRequest searchRequest);
    }
}