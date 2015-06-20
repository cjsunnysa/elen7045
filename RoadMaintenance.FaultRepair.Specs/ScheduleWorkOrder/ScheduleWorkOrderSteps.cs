using System;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.ScheduleWorkOrder
{
    [Binding]
    public class ScheduleWorkOrderSteps
    {
        [Given(@"I have a work order")]
        public void GivenIHaveAWorkOrder(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have a repair team with id (.*) and the following schedule")]
        public void GivenIHaveARepairTeamWithIdAndTheFollowingSchedule(int p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I schedule the work order for ""(.*)""")]
        public void WhenIScheduleTheWorkOrderFor(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the work order scheduling should be ""(.*)""")]
        public void ThenTheWorkOrderSchedulingShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the following resultant schedule for team with id (.*)")]
        public void ThenTheFollowingResultantScheduleForTeamWithId(int p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I unschedule the work order")]
        public void WhenIUnscheduleTheWorkOrder()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the work order unscheduling should be ""(.*)""")]
        public void ThenTheWorkOrderUnschedulingShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
