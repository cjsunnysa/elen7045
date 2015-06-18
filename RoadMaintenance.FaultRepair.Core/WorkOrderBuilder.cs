using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    class WorkOrderBuilder
    {
        private WorkOrder wo;

        public WorkOrderBuilder()
        {
            wo = new WorkOrder();
        }

        public void AddTask(string description)
        {
        }

        public void AddEquipment(string description)
        {
        }

        public void AddMaterial(string description, double quantity)
        {

        }

        public WorkOrder GetResult()
        {
            return wo;
        }



    }
}
