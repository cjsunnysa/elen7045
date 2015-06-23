using System;
using System.Linq;
using Moq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Services.Response;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.AddFault
{
    [Binding]
    public class AddNewFaultSteps
    {
        private CreateFaultResponse _createResponse;

        [Given(@"I am on the Add Fault page")]
        public void GivenIAmOnTheAddFaultPage()
        {
        }
        
        [When(@"I press the Create button")]
        public void WhenIPressTheCreateButton()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            _createResponse = param.Service.CreateFault(new CreateFaultRequest(param.Street1, param.Street2, param.Suburb, param.PostCode, (Core.Enums.Type) param.Type, 1, DateTime.Now));
        }

        [Then(@"result should contain these details")]
        public void ThenResultShouldContainTheseDetails()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            Assert.AreEqual(param.Street1, _createResponse.StreetName);
            Assert.AreEqual(param.Street2, _createResponse.CrossStreet);
            Assert.AreEqual(param.Suburb, _createResponse.Suburb);
            Assert.AreEqual(param.Type, _createResponse.Type);
        }

        [Then(@"the result has a new unique identifier")]
        public void ThenTheResultHasANewUniqueIdentifier()
        {
            Assert.IsNotNullOrEmpty(_createResponse.Id.ToString());
        }

        [Then(@"the result has '(.*)' as the status")]
        public void ThenTheResultHasAsTheStatus(string status)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var description = param.Service.GetStatusDescription(_createResponse.Status);

            Assert.AreEqual(status, description);
        }

    }
}
