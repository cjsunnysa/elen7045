using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Tests
{
    [TestFixture]
    public class WorkOrderBuilderTest
    {
        // Test the correct building of work orders by the work order builder

        [Test]
        public void BuildBasicWorkOrder()
        {
            // Test the creation of a basic work order

            WorkOrderBuilder wob = new WorkOrderBuilder("Basic Work Order");
            WorkOrder wo = wob.GetResult();

            Assert.AreEqual(wo.Description, "Basic Work Order");
            Assert.AreEqual(wo.Status, WorkOrderStatus.Creating);
            Assert.AreEqual(wo.BillOfMaterials.Count, 0);
            Assert.AreEqual(wo.Tasks.Count, 0);
            Assert.AreEqual(wo.Equipment.Count, 0);
        }

        [Test]
        public void AddTasksToWorkOrder()
        {
            // Test the creation of a work order with some tasks

            WorkOrderBuilder wob = new WorkOrderBuilder("Work Order With Tasks");
            wob.AddTask("Task 1");
            wob.AddTask("Task 2");
            wob.AddTask("Task 3");
            WorkOrder wo = wob.GetResult();

            Assert.AreEqual(wo.Description, "Work Order With Tasks");
            Assert.AreEqual(wo.Tasks.Count, 3);
            Assert.AreEqual(wo.Tasks[0].Description, "Task 1");
            Assert.AreEqual(wo.Tasks[1].Description, "Task 2");
            Assert.AreEqual(wo.Tasks[2].Description, "Task 3");
        }

        [Test]
        public void AddMaterialsToWorkOrder()
        {
            // Test the creation of a work order with a bill of materials

            WorkOrderBuilder wob = new WorkOrderBuilder("Work Order With Bill Of Materials");
            wob.AddMaterial("Material 1", 100, MeasurementType.Kg);
            wob.AddMaterial("Material 2", 5, MeasurementType.Items);
            wob.AddMaterial("Material 3", 20, MeasurementType.Liters);
            WorkOrder wo = wob.GetResult();

            Assert.AreEqual(wo.Description, "Work Order With Bill Of Materials");
            Assert.AreEqual(wo.BillOfMaterials.Count, 3);
            Assert.AreEqual(wo.BillOfMaterials[0].Description, "Material 1");
            Assert.AreEqual(wo.BillOfMaterials[0].Quantity, 100);
            Assert.AreEqual(wo.BillOfMaterials[0].QuantityType, MeasurementType.Kg);
        }

        [Test]
        public void AddEquipmentToWorkOrder()
        {
            // Test the creation of a work order with equipment

            WorkOrderBuilder wob = new WorkOrderBuilder("Work Order With Equipment");
            wob.AddEquipment("Tool 1", 5);
            wob.AddEquipment("Tool 2", 100);
            WorkOrder wo = wob.GetResult();

            Assert.AreEqual(wo.Description, "Work Order With Equipment");
            Assert.AreEqual(wo.Equipment.Count, 2);
            Assert.AreEqual(wo.Equipment[1].Description, "Tool 1");
            Assert.AreEqual(wo.Equipment[1].Quantity, 100);
        }

        [Test]
        public void BuildComplexWorkOrder()
        {
            // Test the creation of a complex work order with tasks, materials and equipment

            WorkOrderBuilder wob = new WorkOrderBuilder("Complex Work Order");
            wob.AddTask("Task 1");
            wob.AddTask("Task 2");
            wob.AddTask("Task 3");
            wob.AddMaterial("Material 1", 200, MeasurementType.Kg);
            wob.AddMaterial("Material 2", 10, MeasurementType.Items);
            wob.AddEquipment("Tool 1", 11);
            wob.AddEquipment("Tool 2", 55);
            wob.AddEquipment("Tool 3", 10);
            wob.AddEquipment("Tool 4", 100);
            WorkOrder wo = wob.GetResult();

            Assert.AreEqual(wo.Description, "Complex Work Order");
            Assert.AreEqual(wo.Tasks, 3);
            Assert.AreEqual(wo.BillOfMaterials.Count, 2);
            Assert.AreEqual(wo.Equipment.Count, 4);
        }
    }
}
