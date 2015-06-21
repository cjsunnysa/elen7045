using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Repos;

namespace RoadMaintenance.FaultRepair.Services
{
    public class RepairTeamService
    {
        private IRepairTeamRepository repo;
        public RepairTeamService(IRepairTeamRepository repo)
        {
            this.repo = repo;            
        }

        public IEnumerable<RepairTeamInfo> GetRepairTeams()
        {
            return repo.GeRepairTeams().Select(team => new RepairTeamInfo(team));
        }

        
    }
}
