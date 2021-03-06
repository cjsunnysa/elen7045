﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class WorkOrderBuilder
    {
        private WorkOrder wo;

        public WorkOrderBuilder(string description)
        {
            wo = new WorkOrder();
            wo.Description = description;
            wo.CreationDate = DateTime.Now;
            wo.FaultID = 0;
            wo.Department = string.Empty;
        }

        public WorkOrderBuilder(WorkOrder wo)
        {
            this.wo = wo;
        }

        public void AddTask(string description, byte[] image = null, string imageAnnotation = "")
        {
            wo.Tasks.Add(new WorkOrderTask(WorkOrderTaskStatus.Created, description, image, imageAnnotation));
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
