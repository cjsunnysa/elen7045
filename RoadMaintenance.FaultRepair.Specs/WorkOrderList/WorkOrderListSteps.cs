using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Services;
using RoadMaintenance.SharedKernel.Specs;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderList
{
    [Binding]
    public class WorkOrderListSteps
    {
        [Given(@"these work orders exist")]
        public void GivenTheseWorkOrdersExist(Table table)
        {            
            var workOrderRepo = ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo");
            table.Rows.ForEach(row => workOrderRepo.InsertWorkOrder(new WorkOrder(row[0]) { Status = (WorkOrderStatus)Enum.Parse(typeof(WorkOrderStatus), row[1], true) }));
        }
        
        [When(@"I request a list of unscheduled work orders")]
        public void WhenIRequestAListOfUnscheduledWorkOrders()
        {
            var service = ScenarioContext.Current.Get<IWorkOrderService>("workOrderService");
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
