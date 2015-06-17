using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Repos.Interfaces;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RoadMaintenance.FaultLogging.Specs
{
    [Binding]
    public class SearchFaultsSteps
    {
        private IKernel _kernel;
        private IEnumerable<Fault> _results;
        

        [BeforeScenario]
        public void ScenarioSetUp()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IFaultLoggingRepository>().To<FaultLoggingRepository>();
            _kernel.Bind<FaultSearchRequest>().ToConstant(new FaultSearchRequest());
        }

        [Given(@"I am on the Fault Search page")]
        public void GivenIAmOnTheFaultSearchPage()
        {
        }

        [Given(@"I enter '(.*)' as the street name")]
        public void GivenIEnterAsTheStreetName(string streetName)
        {
            _kernel.Get<FaultSearchRequest>().Street1 = streetName;
        }

        [Given(@"I enter '(.*)' as the suburb name")]
        public void GivenIEnterAsTheSuburbName(string suburb)
        {
            _kernel.Get<FaultSearchRequest>().Suburb = suburb;
        }

        [Given(@"I enter '(.*)' as the cross street name")]
        public void GivenIEnterAsTheCrossStreetName(string crossStreetName)
        {
            _kernel.Get<FaultSearchRequest>().Street2 = crossStreetName;
        }

        [Given(@"I enter '(.*)' as the fault type")]
        public void GivenIEnterAsTheFaultType(int faultTypeId)
        {
            _kernel.Get<FaultSearchRequest>().TypeId = faultTypeId;
        }
        
        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var source = new Mock<IDataStore<Fault>>();
            var data = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();

            source.Setup(instance => instance.Data)
                    .Returns(data);

            _kernel.Bind<IDataStore<Fault>>().ToConstant(source.Object);
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            var repo = _kernel.Get<IFaultLoggingRepository>();
            _results = repo.Find(_kernel.Get<FaultSearchRequest>());
        }

        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            var testSet = table.CreateSet<FaultTest>()
                                .Select(t => t.ToDomainModel());
            
            CollectionAssert.AreEquivalent(testSet, _results);
        }

        [AfterScenario]
        public void SearchFaultStepsTearDown()
        {
            _kernel.Dispose();
        }
    }
}
