using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
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
            var stepParams = new StepParameters { Kernel = new StandardKernel() };
            stepParams.Kernel.Bind<IFaultLoggingRepository>().To<FaultLoggingRepository>();

            ScenarioContext.Current.Add("Params", stepParams);
        }

        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var data = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();

            var mock = new Mock<IDataStore<Fault>>();
            mock.Setup(m => m.Data).Returns(data);

            stepParams.Kernel.Bind<IDataStore<Fault>>().ToConstant(mock.Object);
        }
        
        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");
            
            var testSet = table.CreateSet<FaultTest>()
                                .Select(t => t.ToDomainModel());


            CollectionAssert.AreEquivalent(testSet, stepParams.ResultsCollection);
        }

        [AfterScenario]
        public virtual void SearchFaultStepsTearDown()
        {
            var stepParams = ScenarioContext.Current.Get<StepParameters>("Params");

            stepParams.Kernel.Dispose();
        }
    }
}
