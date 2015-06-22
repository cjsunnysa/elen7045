using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.WorkOrderCreation
{
    [Binding]
    public class WorkOrderCreationSteps
    {
        [Given(@"I have the following work orders in the system")]
        public void GivenIHaveTheFollowingWorkOrdersInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have no work orders in the system")]
        public void GivenIHaveNoWorkOrdersInTheSystem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I create and add a work order")]
        public void WhenICreateAndAddAWorkOrder(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I created a work order as follows")]
        public void WhenICreatedAWorkOrderAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add the following tasks")]
        public void WhenIAddTheFollowingTasks(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add the following equipment")]
        public void WhenIAddTheFollowingEquipment(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add the following material")]
        public void WhenIAddTheFollowingMaterial(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be a new work order number")]
        public void ThenTheResultShouldBeANewWorkOrderNumber()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the work orders in the system should be")]
        public void ThenTheWorkOrdersInTheSystemShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"there should be (.*) work order in the system")]
        public void ThenThereShouldBeWorkOrderInTheSystem(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
