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

        public RepairTeam Find(string id)
        {
            return dummyData.FirstOrDefault(repairTeam => repairTeam.Id == id);
        }

        public void Save(RepairTeam repairTeam)
        {
            var index = dummyData.IndexOf(repairTeam);
            if (index == -1)
                dummyData.Add(repairTeam);
            else
                dummyData[index] = repairTeam;
        }

        public IEnumerable<RepairTeam> GeRepairTeams()
        {
            return dummyData;
        }


        public RepairTeam GetRepairTeamForWorkOrder(string workOrderId)
        {
            return
                dummyData.FirstOrDefault(
                    repairTeam => repairTeam.Schedule.Any(entry => entry.WorkOrderId == workOrderId));
        }
    }
}
