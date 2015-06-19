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
        IWorkOrderRepository workOrderRepo;

        public WorkOrderService(IWorkOrderRepository workOrderRepo) 
        {
            this.workOrderRepo = workOrderRepo;
        }

        public WorkOrder CreateWorkOrder()
        {
            return new WorkOrder();

        }

    }
}
