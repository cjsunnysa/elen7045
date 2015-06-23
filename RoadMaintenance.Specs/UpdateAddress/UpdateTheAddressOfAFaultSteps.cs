using System;
using System.Linq;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.UpdateAddress
{
    [Binding]
    public class UpdateTheAddressOfAFaultSteps
    {
        [Given(@"I am on the Update Address page")]
        public void GivenIAmOnTheUpdateAddressPage()
        {
        }

        [Given(@"I enter '(.*)' as the post code")]
        public void GivenIEnterAsThePostCode(string postCode)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            param.PostCode = postCode;
        }

        
        [When(@"I press the Update Address button")]
        public void WhenIPressTheUpdateAddressButton()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var fault = param.Service.Find(new Guid(param.GivenFaultId));

            param.Street1 = string.IsNullOrEmpty(param.Street1) ? fault.StreetName : param.Street1;
            param.Street2 = string.IsNullOrEmpty(param.Street2) ? fault.CrossStreet : param.Street2;
            param.Suburb = string.IsNullOrEmpty(param.Suburb) ? fault.Suburb : param.Suburb;
            param.PostCode = string.IsNullOrEmpty(param.PostCode) ? fault.PostCode : param.PostCode;


            var request = new UpdateAddressRequest(new Guid(param.GivenFaultId), param.Street1, param.Street2, param.Suburb, param.PostCode);

            param.Service.UpdateAddress(request);
        }
    }
}
