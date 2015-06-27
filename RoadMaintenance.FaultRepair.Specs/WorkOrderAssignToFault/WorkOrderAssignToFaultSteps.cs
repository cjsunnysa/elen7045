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
using RoadMaintenance.SharedKernel.Specs;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderAssignToFault
{
    [Binding]
    public class WorkOrderAssignToFaultSteps
    {
        [Given(@"I have a work order with id ""(.*)""")]
        public void GivenIHaveAWorkOrderWithId(string p0)
        {
            TestKernelBootstrapper.SetupUser("WorkOrderCreationRole");

            var workOrderID = p0;
            var workOrder = new WorkOrder(workOrderID);
            ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo").InsertWorkOrder(workOrder);
            ScenarioContext.Current.Add("workOrderID", workOrderID);
        }
        
        [When(@"I assign the work order to fault id (.*)")]
        public void WhenIAssignTheWorkOrderToFaultId(int p0)
        {
            var woID = ScenarioContext.Current.Get<string>("workOrderID");
            ScenarioContext.Current.Get<IWorkOrderService>("workOrderService").AssignWorkOrderToFault(woID, p0);
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
