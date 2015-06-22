using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderGetDetails
{
    [Binding]
    public class WorkOrderGetDetailsSteps
    {
        [Given(@"The system has a work order")]
        public void GivenTheSystemHasAWorkOrder(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the work order has tasks")]
        public void GivenTheWorkOrderHasTasks(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the work order has equipment")]
        public void GivenTheWorkOrderHasEquipment(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the work order has material")]
        public void GivenTheWorkOrderHasMaterial(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I retrieve the work order details by ID ""(.*)""")]
        public void WhenIRetrieveTheWorkOrderDetailsByID(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the returned work order should have a Description of ""(.*)"", with (.*) tasks, (.*) materials and (.*) equipment allocated")]
        public void ThenTheReturnedWorkOrderShouldHaveADescriptionOfWithTasksMaterialsAndEquipmentAllocated(string p0, int p1, int p2, int p3)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
