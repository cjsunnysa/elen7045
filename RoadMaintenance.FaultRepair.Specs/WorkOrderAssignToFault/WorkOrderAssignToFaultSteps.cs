using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs
{
    [Binding]
    public class WorkOrderAssignToFaultSteps
    {
        [Given(@"I have a fault id (.*)")]
        public void GivenIHaveAFaultId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The status of the fault is not Verified")]
        public void GivenTheStatusOfTheFaultIsNotVerified()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The fault has outstanding work orders assigned to it")]
        public void GivenTheFaultHasOutstandingWorkOrdersAssignedToIt()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have a fault id (.*) with status Verified")]
        public void GivenIHaveAFaultIdWithStatusVerified(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The fault has no outstanding work orders assigned to it")]
        public void GivenTheFaultHasNoOutstandingWorkOrdersAssignedToIt()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I query whether I can assign a work order to this fault")]
        public void WhenIQueryWhetherICanAssignAWorkOrderToThisFault()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
