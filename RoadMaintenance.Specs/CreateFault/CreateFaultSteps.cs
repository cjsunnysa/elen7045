using System.Linq;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.CreateFault
{
    [Binding]
    public class CreateFaultSteps
    {
        [Given(@"I enter '(.*)' as the description")]
        public void GivenIEnterAsTheDescription(string description)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            param.Description = description;
        }

        [When(@"I press the Create button")]
        public void WhenIPressTheCreateButton()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            var operatorId = 1;

            var request = new CreateFaultRequest(
                param.Street1, 
                param.Street2, 
                param.Suburb, 
                param.PostCode,
                (Core.Enums.Type)param.Type,
                param.Description);

            param.GivenFaultId = param.FaultService.CreateFault(request).ToString();
        }

        [Then(@"result should contain these details")]
        public void ThenResultShouldContainTheseDetails()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            Assert.AreEqual(param.Description, param.ResultsCollection.First().Description);
            Assert.AreEqual(param.Street1, param.ResultsCollection.First().StreetName);
            Assert.AreEqual(param.Street2, param.ResultsCollection.First().CrossStreet);
            Assert.AreEqual(param.Suburb,  param.ResultsCollection.First().Suburb);
            Assert.AreEqual(param.Type,    param.ResultsCollection.First().Type);
        }

        [Then(@"the result has '(.*)' as the status")]
        public void ThenTheResultHasAsTheStatus(string status)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            var description = param.FaultService.GetStatusDescription(param.ResultsCollection.First().Status);

            Assert.AreEqual(status, description);
        }

    }
}
