using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Services
{
    public class WorkOrderInfo
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public WorkOrderStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string Department { get; set; }
        public string FaultId { get; set; }
        public IEnumerable<string> Tasks { get; set; }
        public IEnumerable<string> Equipment { get; set; }
        public IEnumerable<string> BillOfMaterials { get; set; }

        public WorkOrderInfo(WorkOrder workOrder)
        {
            this.Id = workOrder.ID;
            this.Description = workOrder.Description;
            this.Status = workOrder.Status;
            this.CreationDate = workOrder.CreationDate;
            this.Department = workOrder.Department;
            this.FaultId = workOrder.FaultID.ToString();
            this.Tasks = workOrder.Tasks.Select(task => String.Format("{0} : {1}", task.Description, task.Status));
            this.Equipment = workOrder.Equipment.Select(equipment => String.Format("{0} : {1}", equipment.Description, equipment.Quantity));
            this.BillOfMaterials = workOrder.BillOfMaterials.Select(material => String.Format("{0} : {1} {2}", material.Description, material.Quantity, material.QuantityType));

        }
    }
}
