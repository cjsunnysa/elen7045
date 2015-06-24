using System;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.UpdateGPSCoordinates
{
    [Binding]
    public class UpdateTheGPSCoordinatesForAFaultSteps
    {
        [Given(@"I enter '(.*)' as the longitude")]
        public void GivenIEnterAsTheLongitude(string longitude)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            param.Longitude = longitude;
        }
        
        [Given(@"I enter '(.*)' as the latitude")]
        public void GivenIEnterAsTheLatitude(string latitude)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            param.Latitude = latitude;
        }
        
        [When(@"I press the Update button")]
        public void WhenIPressTheUpdateButton()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            var faultId = new Guid(param.GivenFaultId);

            try
            {
                param.FaultService.UpdateGpsCoordinates(new UpdateGpsCoordinatesRequest
                {
                    FaultId = faultId,
                    Latitude = param.Latitude,
                    Longitude = param.Longitude
                });
            }
            catch (InvalidOperationException)
            {
                param.InvalidOperationThrown = true;
            }
            catch (ArgumentException)
            {
                param.ArgumentExceptionThrown = true;
            }
        }

        [Then(@"an InvalidOperationException should be thrown")]
        public void ThenAnInvalidOperationExceptionShouldBeThrown()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            Assert.IsTrue(param.InvalidOperationThrown);
        }

        [Then(@"an ArgumentException should be thrown")]
        public void ThenAnArgumentExceptionShouldBeThrown()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            Assert.IsTrue(param.ArgumentExceptionThrown);
        }

    }
}
