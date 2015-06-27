using System;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.CreateCallReference
{
    [Binding]
    public class CreateACallReferenceNumberSteps
    {
        [When(@"I press the Create Call Reference button")]
        public void WhenIPressTheCreateCallReferenceButton()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            var request = new CreateCallRequest
            {
                FaultId = new Guid(param.GivenFaultId),
                CallDateTime = DateTime.Now,
                OperatorId = 1,
            };

            var service = param.FaultService;

            var referenceNumber = service.GetNewCallReference(request);

            param.CallReferenceNumber = referenceNumber;
        }

        [Then(@"a new call reference number should be returned")]
        public void ThenANewCallReferenceNumberShouldBeReturned()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            Assert.IsNotNullOrEmpty(param.CallReferenceNumber);
            Assert.AreEqual(6, param.CallReferenceNumber.Length);
        }

    }
}
