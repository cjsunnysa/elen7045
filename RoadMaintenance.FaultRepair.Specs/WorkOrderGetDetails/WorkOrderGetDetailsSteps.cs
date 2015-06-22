using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Services;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderGetDetails
{
    [Binding]
    public class WorkOrderGetDetailsSteps
    {
        [BeforeScenario]
        public virtual void ScenarioSetUp()
        {
            StandardKernel kernel = new StandardKernel();
            var workOrderRepo = new DummyWorkOrderRepository();

            kernel.Bind<IWorkOrderRepository>().ToConstant(workOrderRepo);

            var service = new WorkOrderService(workOrderRepo);

            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("workOrderRepo", workOrderRepo);
            ScenarioContext.Current.Add("service", service);
        }

        [Given(@"The system has a work order")]
        public void GivenTheSystemHasAWorkOrder(Table table)
        {
            var workOrderID = table.Rows[0][0];
            var workOrder = new WorkOrder(workOrderID);
            workOrder.Description = table.Rows[0][1];
            ScenarioContext.Current.Get<DummyWorkOrderRepository>("workOrderRepo").InsertWorkOrder(workOrder);
            ScenarioContext.Current.Add("workOrderID", workOrderID);
        }
        
        [Given(@"the work order has tasks")]
        public void GivenTheWorkOrderHasTasks(Table table)
        {
            var woID = ScenarioContext.Current.Get<string>("workOrderID");

            var tasks = new List<string>();
            tasks.Add(table.Rows[0][0]);
            tasks.Add(table.Rows[1][0]);
            tasks.Add(table.Rows[2][0]);
            ScenarioContext.Current.Get<WorkOrderService>("service").AmendWorkOrder(woID, tasks, null, null);

        }
        
        [Given(@"the work order has equipment")]
        public void GivenTheWorkOrderHasEquipment(Table table)
        {
            var woID = ScenarioContext.Current.Get<string>("workOrderID");
            var equipment = new List<Tuple<string, int>>();
            equipment.Add(new Tuple<string, int>(table.Rows[0][0], int.Parse(table.Rows[0][1])));
            ScenarioContext.Current.Get<WorkOrderService>("service").AmendWorkOrder(woID, null, equipment, null);
        }
        
        [Given(@"the work order has material")]
        public void GivenTheWorkOrderHasMaterial(Table table)
        {
            var woID = ScenarioContext.Current.Get<string>("workOrderID");
            var billOfMaterial = new List<Tuple<string, double, MeasurementType>>();
            billOfMaterial.Add(new Tuple<string, double, MeasurementType>(table.Rows[0][0], double.Parse(table.Rows[0][1]), MeasurementType.Kg));
            billOfMaterial.Add(new Tuple<string, double, MeasurementType>(table.Rows[1][0], double.Parse(table.Rows[1][1]), MeasurementType.Liters));
            ScenarioContext.Current.Get<WorkOrderService>("service").AmendWorkOrder(woID, null, null, billOfMaterial);
        }
        
        [When(@"I retrieve the work order details by ID ""(.*)""")]
        public void WhenIRetrieveTheWorkOrderDetailsByID(string p0)
        {
           var woID = ScenarioContext.Current.Get<string>("workOrderID");

           string description;
           WorkOrderStatus status;
           DateTime creationDate;
           string department;
           int faultID;
           List<string> tasks;
           List<Tuple<string, int>> equipment;
           List<Tuple<string, double, MeasurementType>> materials;

           ScenarioContext.Current.Get<WorkOrderService>("service").GetWorkOrderDetails(woID, out description, out status, out creationDate, out department, out faultID, out tasks, out equipment, out materials);
           ScenarioContext.Current.Add("description", description);
           ScenarioContext.Current.Add("tasks", tasks);
           ScenarioContext.Current.Add("equipment", equipment);
           ScenarioContext.Current.Add("materials", materials);
        }
        
        [Then(@"the returned work order should have a Description of ""(.*)"", with (.*) tasks, (.*) materials and (.*) equipment allocated")]
        public void ThenTheReturnedWorkOrderShouldHaveADescriptionOfWithTasksMaterialsAndEquipmentAllocated(string p0, int p1, int p2, int p3)
        {
            var description = ScenarioContext.Current.Get<string>("description");
            Assert.AreEqual(p0, description);

            var tasks = ScenarioContext.Current.Get<List<string>>("tasks");
            Assert.AreEqual(p1, tasks.Count);

            var materials = ScenarioContext.Current.Get<List<Tuple<string, double, MeasurementType>>>("materials");
            Assert.AreEqual(p2, materials.Count);

            var equipment = ScenarioContext.Current.Get<List<Tuple<string, int>>>("equipment");
            Assert.AreEqual(p3, equipment.Count);
        }
    }
}
