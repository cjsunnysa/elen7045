using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Services
{
    public class WorkOrderService
    {
        private readonly IWorkOrderRepository workOrderRepo;

        public WorkOrderService(IWorkOrderRepository workOrderRepo) 
        {
            this.workOrderRepo = workOrderRepo;
        }

        public WorkOrder CreateWorkOrder(WorkOrderDTO workOrderDetails)
        {
            // Use factory to create new work order
            WorkOrderBuilder wob = new WorkOrderBuilder("WO001", "New Work Order");

            WorkOrder newWO = wob.GetResult();

            // Insert new work order into repo

            workOrderRepo.InsertWorkOrder(newWO);

            return newWO;
        }
    }
}
