using System;
using System.Linq;
using Moq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RoadMaintenance.FaultLogging.Specs
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
            
            
            var findResult = stepParams.Kernel.Get<IFaultLoggingRepository>().Find(new Guid(stepParams.GivenFaultId));

            stepParams.ResultsCollection = new[] {findResult};
        }
    }
}
