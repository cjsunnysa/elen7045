using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos
{
    public class DummyWorkOrderRepository : IWorkOrderRepository
    {
        private List<WorkOrder> dummyData;

        public DummyWorkOrderRepository()
        {
            // Populate the dummy data
        }

        public WorkOrder GetWorkOrderByID(int id)
        {
            var result = dummyData.First(wo => wo.ID == id);
            return result;
        }


        public List<WorkOrder> GetWorkOrdersByStatus(WorkOrderStatus status)
        {
            var results = dummyData.Where(wo => wo.Status == status);
            return new List<WorkOrder>(results);
        }

        public List<WorkOrder> GetWorkOrdersByFault(int faultID)
        {
            var results = dummyData.Where(wo => wo.FaultID == faultID);
            return new List<WorkOrder>(results);
        }

        public void InsertWorkOrder(WorkOrder wo)
        {
            dummyData.Add(wo);
        }

        public void DeleteWorkOrder(WorkOrder wo)
        {
            dummyData.Remove(wo);
        }


    }
}
