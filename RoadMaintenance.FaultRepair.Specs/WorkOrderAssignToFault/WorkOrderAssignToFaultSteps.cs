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

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderAssignToFault
{
    [Binding]
    public class WorkOrderAssignToFaultSteps
    {
        [BeforeScenario]
        public virtual void ScenarioSetUp()
        {
            StandardKernel kernel = new StandardKernel();
            var workOrderRepo = new DummyWorkOrderRepository();

            kernel.Bind<IWorkOrderRepository>().ToConstant(workOrderRepo);

            var service = new WorkOrderService(workOrderRepo);

            ScenarioContext.Current.Clear();
            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("workOrderRepo", workOrderRepo);
            ScenarioContext.Current.Add("service", service);
        }

        [Given(@"I have a work order with id ""(.*)""")]
        public void GivenIHaveAWorkOrderWithId(string p0)
        {
            var workOrderID = p0;
            var workOrder = new WorkOrder(workOrderID);
            ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo").InsertWorkOrder(workOrder);
            ScenarioContext.Current.Add("workOrderID", workOrderID);
        }
        
        [When(@"I assign the work order to fault id (.*)")]
        public void WhenIAssignTheWorkOrderToFaultId(int p0)
        {
            var woID = ScenarioContext.Current.Get<string>("workOrderID");
            ScenarioContext.Current.Get<WorkOrderService>("service").AssignWorkOrderToFault(woID, p0);
        }
        
        [When(@"I search for all work orders related to fault id (.*)")]
        public void WhenISearchForAllWorkOrdersRelatedToFaultId(int p0)
        {
            List<WorkOrder> workOrders = ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo").GetWorkOrdersByFault(p0);
            ScenarioContext.Current.Add("workOrders", workOrders);
        }
        
        [Then(@"The system should return work order ""(.*)""")]
        public void ThenTheSystemShouldReturnWorkOrder(string p0)
        {
            var workOrders = ScenarioContext.Current.Get<List<WorkOrder>>("workOrders");
            Assert.AreEqual(1, workOrders.Count);

            Assert.AreEqual(workOrders[0].ID, p0);
        }
    }
}
