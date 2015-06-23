using System;
using System.Linq;
using Moq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RoadMaintenance.FaultLogging.Specs
{
    [Binding]
    public class SharedSteps
    {
        [BeforeScenario]
        public virtual void ScenarioSetUp()
        {
            var mock = new Mock<IDataStore<Fault>>();

            var stepParams = new StepParameters
            {
                MockDataSource = mock,
                Service = new FaultService(new FaultLoggingRepository(mock.Object), new FaultFactory()),
            };

            ScenarioContext.Current.Add("Params", stepParams);
        }

        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var data = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();

            stepParams.MockDataSource.Setup(m => m.Data).Returns(data);
        }
        
        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var testSet = table.CreateSet<FaultTest>()
                                .Select(t => t.ToResponse());


            CollectionAssert.AreEquivalent(testSet, stepParams.ResultsCollection);
        }
    }
}
