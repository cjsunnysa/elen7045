using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.FaultVerification.Core.Enums;
using RoadMaintenance.FaultVerification.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using RoadMaintenance.SharedKernel.Repos;
using Type = RoadMaintenance.FaultVerification.Core.Enums.Type;

namespace RoadMaintenance.FaultVerification.Repos.Interfaces
{
    public interface IFaultRepository : IRepository<Guid, Fault>
    {
        IEnumerable<Fault> SearchForFaultsInJurisdiction();
    }
}