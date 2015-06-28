using RoadMaintenance.WorkOrderVerificationResolution.Core;
using RoadMaintenance.WorkOrderVerificationResolution.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Services;

namespace RoadMaintenance.WorkOrderVerificationResolution.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _repo;

        public WorkOrderService(IWorkOrderRepository repo)
        {
            _repo = repo;
        }
        [MethodSecurity]
        public IEnumerable<WorkOrder> GetTopWorkOrders()
        {
            return _repo.GetTopWorkOrders();
        }
    }

}
