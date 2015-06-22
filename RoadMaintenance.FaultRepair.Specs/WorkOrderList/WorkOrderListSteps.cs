using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Services;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderList
{
    [Binding]
    public class WorkOrderListSteps
    {
        [Given(@"these work orders exist")]
        public void GivenTheseWorkOrdersExist(Table table)
        {
            var workOrders = table.Rows.Select(row => new WorkOrder(row[0]) { Status = (WorkOrderStatus)Enum.Parse(typeof(WorkOrderStatus), row[1], true) });
            var repo = new DummyWorkOrderRepository(workOrders);
            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IWorkOrderRepository>().ToConstant(repo);            
            ScenarioContext.Current.Add("kernel", kernel);
        }
        
        [When(@"I request a list of unscheduled work orders")]
        public void WhenIRequestAListOfUnscheduledWorkOrders()
        {
            var service = ScenarioContext.Current.Get<StandardKernel>("kernel").Get<WorkOrderService>();
            ScenarioContext.Current.Add("results", service.GetUnscheduledWorkOrders());
        }
        
        [Then(@"I receive no work orders")]
        public void ThenIReceiveNoWorkOrders()
        {
            Assert.True(!ScenarioContext.Current.Get<IEnumerable<WorkOrderInfo>>("results").Any());
        }
        
        [Then(@"I receive these work orders")]
        public void ThenIReceiveTheseWorkOrders(Table table)
        {
            var results = ScenarioContext.Current.Get<IEnumerable<WorkOrderInfo>>("results").ToList();
            Assert.True(table.RowCount == results.Count);
            Assert.True(table.Rows.Select((row, i) =>
            {
                var result = results[i];
                return row[0] == result.Id &&
                       (WorkOrderStatus) Enum.Parse(typeof (WorkOrderStatus), row[1], true) == result.Status;
            }).All(b => b));
        }
    }
}
