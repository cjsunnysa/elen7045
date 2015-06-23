using System;
using System.Globalization;
using System.Linq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Services;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.ScheduleWorkOrder
{
    [Binding]
    public class ScheduleWorkOrderSteps
    {
        [Given(@"I have a work order")]
        public void GivenIHaveAWorkOrder(Table table)
        {
            var workOrder = new WorkOrder(table.Rows[0][0]) { Duration = int.Parse(table.Rows[0][1])};
            ScenarioContext.Current.Get<DummyWorkOrderRepository>("workOrderRepo").InsertWorkOrder(workOrder);
            ScenarioContext.Current.Add("workOrder", workOrder);

        }

        [Given(@"I have a repair team with id (.*) and the following schedule")]
        public void GivenIHaveARepairTeamWithIdAndTheFollowingSchedule(int p0, Table table)
        {
            var workorderRepo = ScenarioContext.Current.Get<DummyWorkOrderRepository>("workOrderRepo");
            var repairTeam = new RepairTeam() { Id = p0.ToString() };
            repairTeam.Schedule =
                table.Rows.Select(
                    row =>
                    {
                        var entry = new ScheduleEntry(row[0], DateTime.Parse(row[1], new DateTimeFormatInfo()),
                            DateTime.Parse(row[2], new DateTimeFormatInfo()));

                        var workOrder = new WorkOrder(entry.WorkOrderId) {Duration = entry.Duration};
                        workorderRepo.InsertWorkOrder(workOrder);

                        return entry;
                    }).ToList();

            ScenarioContext.Current.Get<DummyRepairTeamRepository>("repairTeamRepo").Save(repairTeam);
        }

        [When(@"I assign the work order to the team with id (.*) for ""(.*)""")]
        public void WhenIAssignTheWorkOrderToTheTeamWithIdFor(int p0, string p1)
        {
            var workOrder = ScenarioContext.Current.Get<WorkOrder>("workOrder");
            var result = ScenarioContext.Current.Get<IRepairTeamService>("repairTeamService").AssignWorkOrder(workOrder.ID, p0.ToString(), DateTime.Parse(p1, new DateTimeFormatInfo()));
            ScenarioContext.Current.Add("result", result);
        }               


        [When(@"I unassign the work order")]
        public void WhenIUnassignTheWorkOrder()
        {
            var workOrder = ScenarioContext.Current.Get<WorkOrder>("workOrder");
            var result = ScenarioContext.Current.Get<IRepairTeamService>("repairTeamService").UnassignWorkOrder(workOrder.ID);
            ScenarioContext.Current.Add("result", result);
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            Assert.True(getResultString(ScenarioContext.Current.Get<bool>("result")) == p0);
        }

        [Then(@"the following resultant schedule for team with id (.*)")]
        public void ThenTheFollowingResultantScheduleForTeamWithId(int p0, Table table)
        {
            var repairTeam = ScenarioContext.Current.Get<IRepairTeamService>("repairTeamService").GetRepairTeam(p0.ToString());
            Assert.NotNull(repairTeam);

            var scheduleEntries = repairTeam.Schedule.ToList();

            Assert.True(table.Rows.Select(
                row => new ScheduleEntry(row[0], DateTime.Parse(row[1], new DateTimeFormatInfo()),
                    DateTime.Parse(row[2], new DateTimeFormatInfo())))
                .Select((rowEntry, i) => rowEntry.Equals(scheduleEntries[i]))
                .All(b => b));
        }

        private string getResultString(bool result)
        {
            return result ? "successful" : "unsuccessful";
        }

    }
}
