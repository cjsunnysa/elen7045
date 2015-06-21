using System;
using Ninject;
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
            var service = ScenarioContext.Current.Get<StandardKernel>("kernel").Get<RepairTeamService>();
            ScenarioContext.Current.Add("results", service.GetRepairTeams());
        }
        
        [Then(@"I get a list of repair teams with schedules as below")]
        public void ThenIGetAListOfRepairTeamsWithSchedulesAsBelow(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
