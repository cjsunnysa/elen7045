using RoadMaintenance.WorkOrderVerificationResolution.Core;
using RoadMaintenance.WorkOrderVerificationResolution.Repos;
using Castle.Core.Internal;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using RoadMaintenance.WorkOrderVerificationResolution.Services;
using System.Collections.Generic;
using NUnit.Framework;

namespace RoadMaintenance.WorkOrderVerificationResolution.Specs.DownloadWorkOrders
{
    [Binding]
    public class DownloadWorkOrdersSteps
    {
        [Given(@"the following work orders")]
        public void GivenTheFollowingWorkOrders(Table table)
        {
            var workOrderRepo = ScenarioContext.Current.Get<IWorkOrderRepository>("workOrderRepo");

            table.Rows.ForEach(row => workOrderRepo.Save(new WorkOrder(row[0]) { Status = (Status)Enum.Parse(typeof(Status), row[1], true), FaultId = row[2], Priority = (Priority)Enum.Parse(typeof(Priority), row[3], true) }));                        
        }
        
        [When(@"I get the top ten work orders")]
        public void WhenIGetTheTopTenWorkOrders()
        {
            //var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            var service = ScenarioContext.Current.Get<IWorkOrderService>("workOrderService");

            var results = service.GetTopWorkOrders();

            ScenarioContext.Current.Add("serviceresults", results);
        }
        
        [Then(@"the result in ascending order is")]
        public void ThenTheResultInAscendingOrderIs(Table table)
        {
            //var expectedData = table.CreateSet<WorkOrder>().ToArray();

            var actualData = ScenarioContext.Current.Get<IEnumerable<WorkOrder>>("serviceresults");
            var enumerator = actualData.GetEnumerator();

            Assert.True(table.Rows.Select((row) =>
                {
                    enumerator.MoveNext();
                    var workOrder = enumerator.Current;
                    return workOrder.Id == row[0] 
                        && workOrder.Status == (Status)Enum.Parse(typeof(Status), row[1], true)
                        && workOrder.FaultId == row[2]
                        && workOrder.Priority == (Priority)Enum.Parse(typeof(Priority), row[3], true);
                }).All(b => b));                        

            //for (var index = 0; index <= expectedData.Count(); index++)
            //{
            //    var expectedRec = expectedData[index];
            //    var actualRec = actualData[index];

            //    Assert.AreEqual(expectedRec.Id, actualRec.Id);
            //    Assert.AreEqual(expectedRec.Priority, actualRec.Priority);
            //}
        }
    }
}
