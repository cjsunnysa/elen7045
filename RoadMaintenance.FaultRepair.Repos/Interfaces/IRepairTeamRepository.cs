using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos.Interfaces
{
    public interface IRepairTeamRepository
    {
        RepairTeam Find(string id);
        void Save(RepairTeam repairTeam);
        IEnumerable<RepairTeam> GeRepairTeams();
        RepairTeam GetRepairTeamForWorkOrder(string workOrderId);
    }
}
