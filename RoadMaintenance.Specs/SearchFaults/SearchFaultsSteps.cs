using System;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs.SearchFaults
{
    [Binding]
    public class SearchFaultsSteps
    {
        [Given(@"I am on the Fault Search page")]
        public void GivenIAmOnTheFaultSearchPage()
        {
        }

        [Given(@"I enter '(.*)' as the street name")]
        public void GivenIEnterAsTheStreetName(string streetName)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            stepParams.Street1 = streetName;
        }

        [Given(@"I enter '(.*)' as the cross street name")]
        public void GivenIEnterAsTheCrossStreetName(string crossStreetName)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            stepParams.Street2 = crossStreetName;
        }

        [Given(@"I enter '(.*)' as the suburb name")]
        public void GivenIEnterAsTheSuburbName(string suburb)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            stepParams.Suburb = suburb;
        }

        [Given(@"I select '(.*)' as the fault type")]
        public void GivenIEnterAsTheFaultType(string faultTypeDescription)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            var faultType = stepParams.Service.GetType(faultTypeDescription);

            stepParams.Type = faultType;
        }

        [Given(@"The date today is '(.*)'")]
        public void GivenTheDateTodayIs(string todayDate)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            stepParams.TodayDate = todayDate.AsDateTime();
        }

        [Given(@"The recently closed fault logging search period is '(.*)' days")]
        public void GivenTheRecentlyClosedFaultLoggingSearchPeriodIsDays(int days)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            Assert.NotNull(stepParams.TodayDate);

            stepParams.RepairedPeriodStartDate = stepParams.TodayDate.Value.AddDays(-days);
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var searchRequest = new FaultSearchRequest
            {
                Type = stepParams.Type,
                Street1 = stepParams.Street1,
                Street2 = stepParams.Street2,
                Suburb = stepParams.Suburb,
                RepairedPeriodStartDate = stepParams.RepairedPeriodStartDate,
                TodayDate = stepParams.TodayDate
            };

            var results = stepParams.Service.Search(searchRequest);

            stepParams.ResultsCollection = results;
        }
    }
}
