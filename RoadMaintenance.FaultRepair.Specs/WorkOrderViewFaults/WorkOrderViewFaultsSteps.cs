using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs
{
    [Binding]
    public class WorkOrderViewFaultsSteps
    {
        [Given(@"These faults were previously logged")]
        public void GivenTheseFaultsWerePreviouslyLogged(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I view all logged faults")]
        public void WhenIViewAllLoggedFaults()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
