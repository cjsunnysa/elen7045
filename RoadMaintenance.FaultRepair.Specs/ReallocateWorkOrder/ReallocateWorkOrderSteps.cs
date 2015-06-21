using System;
using System.Globalization;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Services;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs.ReallocateWorkOrder
{
    [Binding]
    public class ReallocateWorkOrderSteps
    {
        [When(@"I reallocate the work order to team with id (.*) to start at ""(.*)""")]
        public void WhenIReallocateTheWorkOrderToTeamWithIdToStartAt(int p0, string p1)
        {
            
        }
        [When(@"I reallocate the work order with id (.*) to team with id (.*) to start at ""(.*)""")]
        public void WhenIReallocateTheWorkOrderWithIdToTeamWithIdToStartAt(int p0, int p1, string p2)
        {            
            var result = ScenarioContext.Current.Get<RepairTeamService>("service")
                .ReassignWorkOrder(p0.ToString(), p1.ToString(), DateTime.Parse(p2, new DateTimeFormatInfo()));
            ScenarioContext.Current.Add("result", result);
        }

    }
}
