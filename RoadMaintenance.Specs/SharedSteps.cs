using System;
using System.Linq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Services.Interfaces;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.SharedKernel.Specs;
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
            var kernel = TestKernelBootstrapper.InitialiseKernel();
            var scenarioParams = new ScenarioParameters();
            var repo = new DummyFaultRepository();

            kernel.Bind<IFaultService>().To<FaultService>();
            kernel.Bind<IFaultRepository>().ToConstant(repo).InSingletonScope();
            kernel.Bind<DummyFaultRepository>().ToConstant(repo).InSingletonScope();

            SetUpMethodAccessRepo(kernel);

            scenarioParams.FaultService = kernel.Get<IFaultService>();

            ScenarioContext.Current.Add("Params", scenarioParams);
            ScenarioContext.Current.Add("kernel", kernel);
        }

        private void SetUpMethodAccessRepo(StandardKernel kernel)
        {
            var methodAccessRepo = kernel.Get<IMethodAccessRepository>();

            methodAccessRepo.Save(new MethodAccess("FaultService.GetType", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.GetStatusDescription", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.Find", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.Search", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.CreateFault", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.UpdateGpsCoordinates", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.UpdateAddress", "Dispatcher", "CallCenterOperator"));
        }

        [Given(@"the fault I am editing has the Id '(.*)'")]
        public void GivenTheFaultIAmEditingHasTheId(string faultId)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            param.GivenFaultId = faultId;
        }

        [When(@"I perform a find for this fault id")]
        public void WhenIPerformAFindForThisFaultId()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            var faultId = new Guid(param.GivenFaultId);
            
            var fault = param.FaultService.Find(faultId);

            param.ResultsCollection = new[] { fault };
        }

        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            var data = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();

            kernel.Get<DummyFaultRepository>().SetData(data.ToList());
        }
        
        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");
            
            var testSet = table.CreateSet<FaultTest>()
                                .Select(t => t.ToResponse());

            CollectionAssert.AreEquivalent(testSet, param.ResultsCollection);
        }

        [Given(@"I am a '(.*)' user role")]
        public void GivenIAmAUser(string userRole)
        {
            TestKernelBootstrapper.SetupUser(userRole);
        }

    }
}
