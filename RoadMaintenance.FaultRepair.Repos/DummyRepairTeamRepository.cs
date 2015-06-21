using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos
{
    public class DummyRepairTeamRepository : IRepairTeamRepository
    {
        private List<RepairTeam> dummyData;
        public DummyRepairTeamRepository()
        {
            dummyData = new List<RepairTeam>();
        }
        public DummyRepairTeamRepository(IEnumerable<RepairTeam> data)
        {
            dummyData = data.ToList();
        }

        public void AddRepairTeam(RepairTeam repairTeam)
        {
            dummyData.Add(repairTeam);
        }

        public IEnumerable<RepairTeam> GeRepairTeams()
        {
            return dummyData;
        }
    }
}
