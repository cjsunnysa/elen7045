using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos.Interfaces
{
    public interface IWorkOrderRepository
    {        
        List<WorkOrder> GetWorkOrdersByStatus(WorkOrderStatus status);
        List<WorkOrder> GetWorkOrdersByFault(int faultID);
        List<WorkOrder> GetAllWorkOrders();
    }
}
