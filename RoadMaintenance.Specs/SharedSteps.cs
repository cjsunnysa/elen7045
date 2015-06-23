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
            var mockDataStore = new TestDataStore();

            var stepParams = new StepParameters
            {
                MockDataSource = mockDataStore,
                Service = new FaultService(new FaultLoggingRepository(mockDataStore)),
            };

            ScenarioContext.Current.Add("Params", stepParams);
        }

        [Given(@"the fault I am editing has the Id '(.*)'")]
        public void GivenTheFaultIAmEditingHasTheId(string faultId)
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            param.GivenFaultId = faultId;
        }

        [When(@"I perform a find for this fault id")]
        public void WhenIPerformAFindForThisFaultId()
        {
            var param = ScenarioContext.Current.Get<StepParameters>("Params");

            var faultId = new Guid(param.GivenFaultId);

            var fault = param.Service.Find(faultId);

            param.ResultsCollection = new[] { fault };
        }

        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var data = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();

            stepParams.MockDataSource.SetData(data.ToList());
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
