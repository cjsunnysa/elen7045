using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos.Interfaces;
using RoadMaintenance.SharedKernel.Repos;

namespace RoadMaintenance.FaultRepair.Repos
{
    public class DummyRepairTeamRepository : DummyRepo<string, RepairTeam>, IRepairTeamRepository
    {        
        public DummyRepairTeamRepository()
            : base()
        {            
        }
        public DummyRepairTeamRepository(IEnumerable<RepairTeam> data)
            :base(data)
        {            
        }       

        public IEnumerable<RepairTeam> GeRepairTeams()
        {
            return this.entityMap.Values;
        }


        public RepairTeam GetRepairTeamForWorkOrder(string workOrderId)
        {
            return
                entityMap.Values.FirstOrDefault(
                    repairTeam => repairTeam.Schedule.Any(entry => entry.WorkOrderId == workOrderId));
        }
    }
}
