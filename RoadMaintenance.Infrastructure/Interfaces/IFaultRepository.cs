using System;
using System.Collections.Generic;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Model;

namespace RoadMaintenance.FaultLogging.Repos.Interfaces
{
    public interface IFaultRepository
    {
        IEnumerable<Fault> GetAllFaults();
        Fault GetFaultById(Guid id);
        IEnumerable<Fault> GetFaultsBy(SearchDTO search);
    }
}