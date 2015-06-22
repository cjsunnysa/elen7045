using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
using Moq;
>>>>>>> cd5ce2bcac0ec53f34f2b5951c4415b859ad7470
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Services.DTO;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultLogging.Specs
{
    [Binding]
    public class SearchFaultsSteps
    {
        [Given(@"I am on the Fault Search page")]
        public void GivenIAmOnTheFaultSearchPage()
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            stepParams.GivenSearchRequest = new FaultSearchRequest();
        }

        [Given(@"I enter '(.*)' as the street name")]
        public void GivenIEnterAsTheStreetName(string streetName)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            stepParams.GivenSearchRequest.Street1 = streetName;
        }

        [Given(@"I enter '(.*)' as the cross street name")]
        public void GivenIEnterAsTheCrossStreetName(string crossStreetName)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            stepParams.GivenSearchRequest.Street2 = crossStreetName;
        }

        [Given(@"I enter '(.*)' as the suburb name")]
        public void GivenIEnterAsTheSuburbName(string suburb)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            stepParams.GivenSearchRequest.Suburb = suburb;
        }

        [Given(@"I select '(.*)' as the fault type")]
        public void GivenIEnterAsTheFaultType(string faultTypeDescription)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            var service = new FaultService(stepParams.Kernel.Get<IRepository<Fault,Guid>>());
            var faultType = service.GetType(faultTypeDescription);

            stepParams.GivenSearchRequest.Type = faultType;
        }

        [Given(@"The date today is '(.*)'")]
        public void GivenTheDateTodayIs(string todayDate)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            stepParams.GivenSearchRequest.TodayDate = todayDate.AsDateTime();
        }

        [Given(@"The recently closed fault logging search period is '(.*)' days")]
        public void GivenTheRecentlyClosedFaultLoggingSearchPeriodIsDays(int days)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            Assert.NotNull(stepParams.GivenSearchRequest.TodayDate);

            stepParams.GivenSearchRequest.RepairedPeriodStartDate = stepParams.GivenSearchRequest.TodayDate.Value.AddDays(-days);
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var repo = stepParams.Kernel.Get<IRepository<Fault,Guid>>();
            var results = new FaultService(repo).Search(stepParams.GivenSearchRequest);

            stepParams.ResultsCollection = results;
        }
    }
}
