using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos
{
    public interface IWorkOrderRepository
    {
        WorkOrder GetWorkOrderByID(string id);
        List<WorkOrder> GetWorkOrdersByStatus(WorkOrderStatus status);
        List<WorkOrder> GetWorkOrdersByFault(int faultID);

        void InsertWorkOrder(WorkOrder wo);
        void DeleteWorkOrder(WorkOrder wo);
    }
}
