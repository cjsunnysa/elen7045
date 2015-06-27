using RoadMaintenance.WorkOrderVerificationResolution.Core;
using System;
namespace RoadMaintenance.WorkOrderVerificationResolution.Services
{
    public interface IWorkOrderService
    {
        System.Collections.Generic.IEnumerable<WorkOrder> GetTopWorkOrders();
    }
}
