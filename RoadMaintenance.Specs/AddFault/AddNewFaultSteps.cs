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
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.AddFault
{
    [Binding]
    public class AddNewFaultSteps
    {
        [Given(@"I am on the Add Fault page")]
        public void GivenIAmOnTheAddFaultPage()
        {
        }
        
        [When(@"I press the Create button")]
        public void WhenIPressTheCreateButton()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var operatorId = 1;

            var request = new CreateFaultRequest(
                param.Street1, 
                param.Street2, 
                param.Suburb, 
                param.PostCode,
                (Core.Enums.Type)param.Type);

            param.GivenFaultId = param.Service.CreateFault(request).ToString();
        }

        [Then(@"result should contain these details")]
        public void ThenResultShouldContainTheseDetails()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            Assert.AreEqual(param.Street1, param.ResultsCollection.First().StreetName);
            Assert.AreEqual(param.Street2, param.ResultsCollection.First().CrossStreet);
            Assert.AreEqual(param.Suburb,  param.ResultsCollection.First().Suburb);
            Assert.AreEqual(param.Type,    param.ResultsCollection.First().Type);
        }

        [Then(@"the result has '(.*)' as the status")]
        public void ThenTheResultHasAsTheStatus(string status)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var description = param.Service.GetStatusDescription(param.ResultsCollection.First().Status);

            Assert.AreEqual(status, description);
        }

    }
}
