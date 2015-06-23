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

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderCreation
{
    [Binding]
    public class WorkOrderCreationSteps
    {

        [BeforeScenario]
        public virtual void ScenarioSetUp()
        {
            StandardKernel kernel = new StandardKernel();
            var workOrderRepo = new DummyWorkOrderRepository();

            // Bind the dummy work order repository to IWorkOrderRepository and inject
            kernel.Bind<IWorkOrderRepository>().ToConstant(workOrderRepo);

            var service = new WorkOrderService(workOrderRepo);

            ScenarioContext.Current.Clear();
            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("workOrderRepo", workOrderRepo);
            ScenarioContext.Current.Add("service", service);
        }

        /// <summary>
        /// First scenario
        /// </summary>


        [Given(@"I have the following work orders in the system")]
        public void GivenIHaveTheFollowingWorkOrdersInTheSystem(Table table)
        {
            var workOrder = new WorkOrder("WO1");
            workOrder.Description = table.Rows[0][0];
            ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo").InsertWorkOrder(workOrder);
        }

        [When(@"I create and add a work order")]
        public void WhenICreateAndAddAWorkOrder(Table table)
        {
            var newWOID = ScenarioContext.Current.Get<WorkOrderService>("service").CreateWorkOrder(table.Rows[0][0], null, null, null);
            ScenarioContext.Current.Add("newWorkOrderID", newWOID);
        }

        [Then(@"the result should be a new work order number")]
        public void ThenTheResultShouldBeANewWorkOrderNumber()
        {
            Assert.True(ScenarioContext.Current.Get<string>("newWorkOrderID") != string.Empty);
        }

        [Then(@"the work orders in the system should be")]
        public void ThenTheWorkOrdersInTheSystemShouldBe(Table table)
        {
            List<WorkOrder> systemWorkOrders = ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo").GetAllWorkOrders();
            Assert.AreEqual(systemWorkOrders.Count, 2);
            Assert.AreEqual(table.Rows[0][0], systemWorkOrders[0].Description);
            Assert.AreEqual(table.Rows[1][0], systemWorkOrders[1].Description);
        }

        /// <summary>
        /// Second scenario
        /// </summary>

        [Given(@"I have no work orders in the system")]
        public void GivenIHaveNoWorkOrdersInTheSystem()
        {
        }

        [When(@"I created a work order as follows")]
        public void WhenICreatedAWorkOrderAsFollows(Table table)
        {
            var newWOID = ScenarioContext.Current.Get<WorkOrderService>("service").CreateWorkOrder(table.Rows[0][0], null, null, null);
            ScenarioContext.Current.Add("newWorkOrderID", newWOID);
        }

        [When(@"I add the following tasks")]
        public void WhenIAddTheFollowingTasks(Table table)
        {
            var woID = ScenarioContext.Current.Get<string>("newWorkOrderID");
            var tasks = new List<string>();
            tasks.Add(table.Rows[0][0]);
            tasks.Add(table.Rows[1][0]);
            tasks.Add(table.Rows[2][0]);
            ScenarioContext.Current.Get<WorkOrderService>("service").AmendWorkOrder(woID, tasks, null, null);
        }

        [When(@"I add the following equipment")]
        public void WhenIAddTheFollowingEquipment(Table table)
        {
            var woID = ScenarioContext.Current.Get<string>("newWorkOrderID");
            var equipment = new List<Tuple<string, int>>();
            equipment.Add(new Tuple<string, int>(table.Rows[0][0], int.Parse(table.Rows[0][1])));
            ScenarioContext.Current.Get<WorkOrderService>("service").AmendWorkOrder(woID, null, equipment, null);
        }

        [When(@"I add the following material")]
        public void WhenIAddTheFollowingMaterial(Table table)
        {
            var woID = ScenarioContext.Current.Get<string>("newWorkOrderID");
            var billOfMaterial = new List<Tuple<string, double, MeasurementType>>();
            billOfMaterial.Add(new Tuple<string, double, MeasurementType>(table.Rows[0][0], double.Parse(table.Rows[0][1]), MeasurementType.Kg));
            billOfMaterial.Add(new Tuple<string, double, MeasurementType>(table.Rows[1][0], double.Parse(table.Rows[1][1]), MeasurementType.Liters));
            ScenarioContext.Current.Get<WorkOrderService>("service").AmendWorkOrder(woID, null, null, billOfMaterial);
        }

        [Then(@"the result should be a new work order number created")]
        public void ThenTheResultShouldBeANewWorkOrderNumberCreated()
        {
            Assert.True(ScenarioContext.Current.Get<string>("newWorkOrderID") != string.Empty);
        }


        [Then(@"there should be (.*) work order in the system")]
        public void ThenThereShouldBeWorkOrderInTheSystem(int p0)
        {
            List<WorkOrder> systemWorkOrders = ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo").GetAllWorkOrders();
            Assert.AreEqual(systemWorkOrders.Count, p0);
        }
    }
}
