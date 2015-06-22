using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs
{
    [Binding]
    public class WorkOrderGetFaultDetailsSteps
    {
        [Given(@"These report cards were created")]
        public void GivenTheseReportCardsWereCreated(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I fetch the report card details for fault id (.*)")]
        public void WhenIFetchTheReportCardDetailsForFaultId(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
