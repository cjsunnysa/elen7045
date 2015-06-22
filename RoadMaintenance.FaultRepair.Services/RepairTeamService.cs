using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Repos;

namespace RoadMaintenance.FaultRepair.Services
{
    public class RepairTeamService
    {
        private IRepairTeamRepository repairTeamRepo;
        private IWorkOrderRepository workOrderRepo;

        public RepairTeamService(IRepairTeamRepository repairTeamRepo, IWorkOrderRepository workOrderRepo)
        {
            this.repairTeamRepo = repairTeamRepo;
            this.workOrderRepo = workOrderRepo;
        }

        public RepairTeamInfo GetRepairTeam(string id)
        {
            var repairTeam = repairTeamRepo.Find(id);
            return repairTeam == null ? null : new RepairTeamInfo(repairTeam);
        }

        public IEnumerable<RepairTeamInfo> GetRepairTeams()
        {
            return repairTeamRepo.GeRepairTeams().Select(team => new RepairTeamInfo(team));
        }

        public bool AssignWorkOrder(string workOrderId, string repairTeamId, DateTime workOrderStartTime)
        {
            var workOrder = workOrderRepo.GetWorkOrderByID(workOrderId);
            var repairTeam = repairTeamRepo.Find(repairTeamId);

            var result = repairTeam.Assign(workOrder, workOrderStartTime);
            if (result)
                repairTeamRepo.Save(repairTeam);

            return result;
        }

        public bool UnassignWorkOrder(string workOrderId)
        {
            var repairTeam = repairTeamRepo.GetRepairTeamForWorkOrder(workOrderId);
            if (repairTeam == null)
                return false;

            var result = repairTeam.UnassignWorkOrder(workOrderId);
            if (result)
                repairTeamRepo.Save(repairTeam);

            return result;
        }        

        public bool ReassignWorkOrder(string workOrderId, string repairTeamId, DateTime workOrderStartTime)
        {
            var oldRepairTeam = repairTeamRepo.GetRepairTeamForWorkOrder(workOrderId);

            var workOrder = workOrderRepo.GetWorkOrderByID(workOrderId);
            var repairTeam = repairTeamRepo.Find(repairTeamId);

            var result = repairTeam.Assign(workOrder, workOrderStartTime);
            if (result)
            {
                if (oldRepairTeam != null)
                {
                    if (!oldRepairTeam.UnassignWorkOrder(workOrderId))
                        return false;

                    repairTeamRepo.Save(oldRepairTeam);
                }                
                repairTeamRepo.Save(repairTeam);
            }

            return result;
        }
    }
}
