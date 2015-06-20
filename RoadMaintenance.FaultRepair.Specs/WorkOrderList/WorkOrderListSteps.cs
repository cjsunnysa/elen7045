using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderList
{
    [Binding]
    public class WorkOrderListSteps
    {
        [Given(@"these work orders exist")]
        public void GivenTheseWorkOrdersExist(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request a list of unscheduled work orders")]
        public void WhenIRequestAListOfUnscheduledWorkOrders()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive no work orders")]
        public void ThenIReceiveNoWorkOrders()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive these work orders")]
        public void ThenIReceiveTheseWorkOrders(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
