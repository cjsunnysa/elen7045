using System;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using RoadMaintenance.SharedKernel.Repos;

namespace RoadMaintenance.FaultLogging.Repos.Interfaces
{
    public interface IFaultRepository : IRepository<Fault, Guid>
    {

    }
}