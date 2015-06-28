using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using RoadMaintenance.SharedKernel.Repos;

namespace RoadMaintenance.FaultLogging.Repos.Interfaces
{
    public interface IFaultRepository
    {
        Fault Find(Guid id);
        IQueryable<Fault> Search();
        void Save(Fault entity);
    }
}