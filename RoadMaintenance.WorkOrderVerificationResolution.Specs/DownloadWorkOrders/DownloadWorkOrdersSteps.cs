using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.WorkOrderVerificationResolution.Specs.DownloadWorkOrders
{
    [Binding]
    public class DownloadWorkOrdersSteps
    {
        [Given(@"the following work orders")]
        public void GivenTheFollowingWorkOrders(Table table)
        {
            //var repo = ScenarioContext.Current.Get<DummyWorkOrderRepository>("repo");

            //var workOrderData = table.CreateSet<WorkOrder>();

            //repo.SetData(workOrderData.ToList());
        }
        
        [When(@"I get the top ten work orders")]
        public void WhenIGetTheTopTenWorkOrders()
        {
            //var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            //var service = kernel.Get<IWorkOrderService>();

            //var results = service.GetTopWorkOrders();

            //ScenarioContext.Current.Add("serviceresults", results);
        }
        
        [Then(@"the result in ascending order is")]
        public void ThenTheResultInAscendingOrderIs(Table table)
        {
            //var expectedData = table.CreateSet<WorkOrder>().ToArray();

            //var actualData = ScenarioContext.Current.Get<IEnumerable<WorkOrder>>("serviceresults").ToArray();

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
