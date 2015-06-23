using System;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Specs.Model;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.UpdateGPSCoordinates
{
    [Binding]
    public class UpdateTheGPSCoordinatesForAFaultSteps
    {
        [Given(@"I am on the Add GPS Coordinates page")]
        public void GivenIAmOnTheAddGPSCoordinatesPage()
        {
        }
        
        [Given(@"the fault I am editing has the Id '(.*)'")]
        public void GivenTheFaultIAmEditingHasTheId(string faultId)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            param.GivenFaultId = faultId;
        }
        
        [Given(@"I enter '(.*)' as the longitude")]
        public void GivenIEnterAsTheLongitude(string longitude)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            param.Longitude = longitude;
        }
        
        [Given(@"I enter '(.*)' as the latitude")]
        public void GivenIEnterAsTheLatitude(string latitude)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            param.Latitude = latitude;
        }
        
        [When(@"I press the Update button")]
        public void WhenIPressTheUpdateButton()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var faultId = new Guid(param.GivenFaultId);

            param.Service.UpdateFaultGpsCoordinates(new UpdateGpsCoordinatesRequest
            {
                FaultId = faultId,
                Latitude = param.Latitude,
                Longitude = param.Longitude
            });
        }

        [When(@"I perform a find for this fault id")]
        public void WhenIPerformAFindForThisFaultId()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var faultId = new Guid(param.GivenFaultId);

            var fault = param.Service.Find(faultId);

            param.ResultsCollection = new[] {fault};
        }
    }
}
