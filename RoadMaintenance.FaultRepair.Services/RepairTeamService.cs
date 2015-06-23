using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.SharedKernel.Services;

namespace RoadMaintenance.FaultRepair.Services
{
    public interface IRepairTeamService
    {
        RepairTeamInfo GetRepairTeam(string id);        
        IEnumerable<RepairTeamInfo> GetRepairTeams();
        bool AssignWorkOrder(string workOrderId, string repairTeamId, DateTime workOrderStartTime);
        bool UnassignWorkOrder(string workOrderId);
        bool ReassignWorkOrder(string workOrderId, string repairTeamId, DateTime workOrderStartTime);
    }

    public class RepairTeamService : IRepairTeamService
    {
        private IRepairTeamRepository repairTeamRepo;
        private IWorkOrderRepository workOrderRepo;

        public RepairTeamService(IRepairTeamRepository repairTeamRepo, IWorkOrderRepository workOrderRepo)
        {
            this.repairTeamRepo = repairTeamRepo;
            this.workOrderRepo = workOrderRepo;
        }

        [MethodSecurity]
        public RepairTeamInfo GetRepairTeam(string id)
        {
            var repairTeam = repairTeamRepo.Find(id);
            return repairTeam == null ? null : new RepairTeamInfo(repairTeam);
        }

        [MethodSecurity]
        public IEnumerable<RepairTeamInfo> GetRepairTeams()
        {
            return repairTeamRepo.GeRepairTeams().Select(team => new RepairTeamInfo(team));
        }

        [MethodSecurity]
        public bool AssignWorkOrder(string workOrderId, string repairTeamId, DateTime workOrderStartTime)
        {
            var workOrder = workOrderRepo.GetWorkOrderByID(workOrderId);
            var repairTeam = repairTeamRepo.Find(repairTeamId);

            var result = repairTeam.Assign(workOrder, workOrderStartTime);
            if (result)
                repairTeamRepo.Save(repairTeam);

            return result;
        }

        [MethodSecurity]
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

        [MethodSecurity]
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
