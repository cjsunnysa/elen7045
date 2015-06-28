using Ninject;
using RoadMaintenance.SharedKernel.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using RoadMaintenance.FaultVerification.Repos;
using RoadMaintenance.FaultVerification.Services.Interfaces;
using RoadMaintenance.FaultVerification.Services;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.FaultVerification.Repos.Interfaces;

namespace RoadMaintenance.FaultVerification.Specs
{
    [Binding]
    class SharedSteps
    {
        [BeforeScenario]
        public void ScenarioSetUp()
        {
            var kernel = TestKernelBootstrapper.InitialiseKernel();
            //var scenarioParams = new ScenarioParameters();
            var repo = new DummyFaultRepository();

            kernel.Bind<IFaultService>().To<FaultService>();
            kernel.Bind<IFaultRepository>().ToConstant(repo).InSingletonScope();
            kernel.Bind<DummyFaultRepository>().ToConstant(repo).InSingletonScope();

            SetUpMethodAccessRepo(kernel);

            var faultService = kernel.Get<IFaultService>();

            ScenarioContext.Current.Add("faultService", faultService);
            ScenarioContext.Current.Add("kernel", kernel);
        }

        private void SetUpMethodAccessRepo(StandardKernel kernel)
        {
            var methodAccessRepo = kernel.Get<IMethodAccessRepository>();

            methodAccessRepo.Save(new MethodAccess("FaultService.GetJurisdictionFaults", "Dispatcher", "FaultInvestigator"));
        }


        [AfterScenario]
        public void ScenarioTearDown()
        {
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            kernel.Dispose();
        }
    }
}
