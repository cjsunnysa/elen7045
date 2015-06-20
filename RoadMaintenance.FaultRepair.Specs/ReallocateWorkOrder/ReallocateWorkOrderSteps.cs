using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.ReallocateWorkOrder
{
    [Binding]
    public class ReallocateWorkOrderSteps
    {
        [Given(@"I have a work order with id (.*)")]
        public void GivenIHaveAWorkOrderWithId(int p0)
        {
            ScenarioContext.Current.Pending();
        }               
        
        [When(@"I reallocate the work order to team with id (.*) to start at ""(.*)""")]
        public void WhenIReallocateTheWorkOrderToTeamWithIdToStartAt(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the work order reallocation should be ""(.*)""")]
        public void ThenTheWorkOrderReallocationShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
