using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Parameters;
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.SharedKernel.Services;
using RoadMaintenance.SharedKernel.Specs;
using TechTalk.SpecFlow;
using RoadMaintenance.WorkOrderVerificationResolution.Repos;
using RoadMaintenance.WorkOrderVerificationResolution.Services;

namespace RoadMaintenance.WorkOrderVerificationResolution.Specs
{
        [Binding]
        public class ScenarioSetup
        {
            [BeforeScenario]
            public virtual void ScenarioSetUp()
            {
                var kernel = TestKernelBootstrapper.InitialiseKernel();
                var workOrderRepo = new DummyWorkOrderRepository();

                kernel.Bind<IWorkOrderRepository>().ToConstant(workOrderRepo).InSingletonScope();

                kernel.Bind<IWorkOrderService>().To<WorkOrderService>();

                var workOrderService = kernel.Get<IWorkOrderService>();

                ScenarioContext.Current.Add("kernel", kernel);
                ScenarioContext.Current.Add("workOrderRepo", workOrderRepo);
                ScenarioContext.Current.Add("workOrderService", workOrderService);

                setupMethodAccessRepo(kernel);

            }
            [AfterScenario]
            public void ScenarioTearDown()
            {
                var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

                kernel.Dispose();
            }
            private void setupMethodAccessRepo(StandardKernel kernel)
            {
                var methodAccessRepo = kernel.Get<IMethodAccessRepository>();

                methodAccessRepo.Save(new MethodAccess("workOrderService.GetTopWorkOrders", "Inspector"));
            }

            [Given(@"I am a ""(.*)""")]
            public void GivenIAmA(string p0)
            {
                TestKernelBootstrapper.SetupUser(p0);
            }
        }
}