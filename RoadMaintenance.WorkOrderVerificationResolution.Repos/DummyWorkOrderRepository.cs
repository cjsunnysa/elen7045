using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.WorkOrderVerificationResolution.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.WorkOrderVerificationResolution.Repos
{
    public class DummyWorkOrderRepository : DummyRepo<string, WorkOrder>, IWorkOrderRepository
    {
        public IEnumerable<WorkOrder> GetTopWorkOrders()
        {
            return (from d in entityMap.Values
                    where
                        d.Status.Equals(Status.AwaitingVerification)
                    orderby d.Priority descending, int.Parse(d.Id) ascending
                    select d).Take(10);
        }
    }
}
