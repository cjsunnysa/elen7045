using System;
using Ninject;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.FindFault
{
    [Binding]
    public class FindFaultSteps
    {
        [Given(@"I am on the Find Fault page")]
        public void GivenIAmOnTheFindFaultPage()
        {
        }

        [Given(@"I enter '(.*)' as the fault identification number")]
        public void GivenIEnterAsTheFaultIdentificationNumber(string faultIdentificationNumber)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            stepParams.GivenFaultId = faultIdentificationNumber;
        }
        
        [When(@"I press the Find button")]
        public void WhenIPressTheFindButton()
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            var findResult = stepParams.Service.Find(new Guid(stepParams.GivenFaultId));

            stepParams.ResultsCollection = new[] {findResult};
        }
    }
}
