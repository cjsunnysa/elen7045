using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FaultLogging.Core.Model;
using FaultLogging.Persistence;
using FaultLogging.Persistence.Interfaces;
using FaultLogging.Specs.Model;
using Moq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.MVC.Controllers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FaultLogging.Specs
{
    [Binding]
    public class SearchFaultsSteps
    {
        private IKernel _kernel;
        private SearchDTO _searchDTO;
        private ViewResult _results;
        

        [BeforeScenario]
        public void ScenarioSetUp()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IFaultRepository>().To<FaultRepository>();
            _searchDTO = new SearchDTO();
        }

        [Given(@"I am on the Fault Search page")]
        public void GivenIAmOnTheFaultSearchPage()
        {
            _kernel.Bind<SearchController>().ToSelf();
        }

        [Given(@"I enter '(.*)' as the street name")]
        public void GivenIEnterAsTheStreetName(string streetName)
        {
            _searchDTO.Street1 = streetName;
        }

        [Given(@"I enter '(.*)' as the suburb name")]
        public void GivenIEnterAsTheSuburbName(string suburb)
        {
            _searchDTO.Suburb = suburb;
        }

        [Given(@"I enter '(.*)' as the cross street name")]
        public void GivenIEnterAsTheCrossStreetName(string crossStreetName)
        {
            _searchDTO.Street2 = crossStreetName;
        }

        [Given(@"I enter '(.*)' as the fault type")]
        public void GivenIEnterAsTheFaultType(int faultTypeId)
        {
            _searchDTO.TypeId = faultTypeId;
        }
        
        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var data = table.CreateSet<FaultTest>().ToArray();
            var moqDataSource = new Mock<IDataStore<Fault>>();
            
            moqDataSource.Setup(instance => instance.GetAllData()).Returns(data.Select(t => t.ToDomainModel()));

            _kernel.Bind<IDataStore<Fault>>().ToConstant(moqDataSource.Object);
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            _results = _kernel.Get<SearchController>().SearchResults(_searchDTO);
        }

        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            var testSet = table.CreateSet<FaultTest>().Select(t => t.ToDomainModel());
            var resultSet = (IEnumerable<Fault>)_results.Model;
            

            CollectionAssert.AreEquivalent(testSet, resultSet);
        }

        [AfterScenario]
        public void SearchFaultStepsTearDown()
        {
            _kernel.Dispose();
        }
    }
}
