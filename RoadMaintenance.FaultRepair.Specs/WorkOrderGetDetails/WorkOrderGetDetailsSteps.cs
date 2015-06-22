using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderGetDetails
{
    [Binding]
    public class WorkOrderGetDetailsSteps
    {
        [Given(@"I have created a work order as follows")]
        public void GivenIHaveCreatedAWorkOrderAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The work order has the following tasks")]
        public void GivenTheWorkOrderHasTheFollowingTasks(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"And the work order has the following equipment")]
        public void GivenAndTheWorkOrderHasTheFollowingEquipment(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"And the work order has the following material")]
        public void GivenAndTheWorkOrderHasTheFollowingMaterial(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I retrieve the work order")]
        public void WhenIRetrieveTheWorkOrder()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the returned work order should have a Description of ""(.*)""")]
        public void ThenTheReturnedWorkOrderShouldHaveADescriptionOf(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the returned work order should have (.*) tasks allocated")]
        public void ThenTheReturnedWorkOrderShouldHaveTasksAllocated(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the returned work order should have (.*) materials allocated")]
        public void ThenTheReturnedWorkOrderShouldHaveMaterialsAllocated(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the returned work order should have (.*) equipment allocated")]
        public void ThenTheReturnedWorkOrderShouldHaveEquipmentAllocated(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
