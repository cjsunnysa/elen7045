using System;
using System.Globalization;
using System.Linq;
using Ninject;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.ScheduleWorkOrder
{
    [Binding]
    public class ScheduleWorkOrderSteps
    {
        [BeforeScenario]
        public virtual void ScenarioSetUp()
        {                        
            StandardKernel kernel = new StandardKernel();
            var repairTeamRepo = new DummyRepairTeamRepository();
            kernel.Bind<IRepairTeamRepository>().ToConstant(repairTeamRepo);
            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("repairTeamRepo", repairTeamRepo);
        }

        [Given(@"I have a work order")]
        public void GivenIHaveAWorkOrder(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have a repair team with id (.*) and the following schedule")]
        public void GivenIHaveARepairTeamWithIdAndTheFollowingSchedule(int p0, Table table)
        {
            var repairTeam = new RepairTeam() { Id = p0.ToString() };
            repairTeam.Schedule =
                table.Rows.Select(
                    row =>
                        new ScheduleEntry(row[0], DateTime.Parse(row[1], new DateTimeFormatInfo()),
                            DateTime.Parse(row[2], new DateTimeFormatInfo()))).ToList();

            ScenarioContext.Current.Get<DummyRepairTeamRepository>("repairTeamRepo").AddRepairTeam(repairTeam);
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
