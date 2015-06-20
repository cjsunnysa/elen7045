using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs
{
    [Binding]
    public class WorkOrderFaultNotModifiedSteps
    {
        [Given(@"Fault ID (.*) is being modified by another user")]
        public void GivenFaultIDIsBeingModifiedByAnotherUser(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Fault ID (.*) is not being modified by another user")]
        public void GivenFaultIDIsNotBeingModifiedByAnotherUser(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enquire whether Fault ID (.*) is being modified")]
        public void WhenIEnquireWhetherFaultIDIsBeingModified(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
