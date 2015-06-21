using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Services;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.RepairTeamList
{
    [Binding]
    public class RepairTeamListSteps
    {
        [When(@"I request a list of repair teams")]
        public void WhenIRequestAListOfRepairTeams()
        {
            var service = ScenarioContext.Current.Get<RepairTeamService>("service");
            ScenarioContext.Current.Add("results", service.GetRepairTeams());
        }
        
        [Then(@"I get a list of repair teams with schedules as below")]
        public void ThenIGetAListOfRepairTeamsWithSchedulesAsBelow(Table table)
        {
            var results = ScenarioContext.Current.Get<IEnumerable<RepairTeamInfo>>("results").ToList();            

            var rowsByTeamId = table.Rows.GroupBy(row => row[0]);
            
            Assert.True(rowsByTeamId.Select((group, i) =>
            {
                var repairTeam = results[i];
                if (repairTeam.Id != group.Key)
                    return false;

                var scheduleEntries = repairTeam.Schedule.ToList();

                return group.Select(
                    row =>
                        new ScheduleEntry(row[1], DateTime.Parse(row[2], new DateTimeFormatInfo()),
                            DateTime.Parse(row[3], new DateTimeFormatInfo())))
                    .Select((rowEntry, j) => rowEntry.Equals(scheduleEntries[j]))
                    .All(b => b);                                
            }).All(b => b));            
        }
    }
}
