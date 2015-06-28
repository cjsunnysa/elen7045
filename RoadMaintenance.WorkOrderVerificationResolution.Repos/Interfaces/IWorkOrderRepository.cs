using RoadMaintenance.WorkOrderVerificationResolution.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Repos;

namespace RoadMaintenance.WorkOrderVerificationResolution.Repos
{
    public interface IWorkOrderRepository : IRepository<string, WorkOrder>
    {
        IEnumerable<WorkOrder> GetTopWorkOrders();
    }
}
