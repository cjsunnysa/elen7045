using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class WorkOrderBuilder
    {
        private WorkOrder wo;

        public WorkOrderBuilder()
        {
            wo = new WorkOrder();
            wo.CreationDate = DateTime.Now;
            wo.FaultID = 0;
            wo.Department = string.Empty;
        }

        public void AddTask(string description)
        {
            wo.Tasks.Add(new WorkOrderTask(WorkOrderTaskStatus.Created, description));
        }

        public void AddEquipment(string description)
        {
            wo.Equipment.Add(new Equipment(description));
        }

        public void AddMaterial(string description, double quantity)
        {
            wo.BillOfMaterials.Add(new BillOfMaterialsItem(description, quantity, MeasurementType.Amount));
        }

        public WorkOrder GetResult()
        {
            return wo;
        }
    }
}
