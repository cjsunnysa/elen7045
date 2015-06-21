using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos
{
    public interface IRepairTeamRepository
    {
        IEnumerable<RepairTeam> GeRepairTeams();        
    }
}
