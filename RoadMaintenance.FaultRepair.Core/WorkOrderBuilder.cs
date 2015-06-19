using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class WorkOrderBuilder
    {
        private WorkOrder wo;

        public WorkOrderBuilder(string id, string description)
        {
            wo = new WorkOrder();
            wo.ID = id;
            wo.Description = description;
            wo.CreationDate = DateTime.Now;
            wo.FaultID = 0;
            wo.Department = string.Empty;
        }

        public void AddTask(string description)
        {
            wo.Tasks.Add(new WorkOrderTask(WorkOrderTaskStatus.Created, description));
        }

        public void AddEquipment(string description, int quantity)
        {
            wo.Equipment.Add(new Equipment(description, quantity));
        }

        public void AddMaterial(string description, double quantity, MeasurementType mType)
        {
            wo.BillOfMaterials.Add(new BillOfMaterialsItem(description, quantity, mType));
        }

        public WorkOrder GetResult()
        {
            return wo;
        }
    }
}
