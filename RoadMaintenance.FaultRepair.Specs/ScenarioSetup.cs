using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Parameters;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Services;
using RoadMaintenance.SharedKernel.Services;
using RoadMaintenance.SharedKernel.Specs;
using TechTalk.SpecFlow;

namespace RoadMaintenance.FaultRepair.Specs
{
    [Binding]
    public class ScenarioSetup
    {        
        [BeforeScenario]
        public virtual void ScenarioSetUp()
        {
            var kernel = TestKernelBootstrapper.InitialiseKernel();
            var workOrderRepo = new DummyWorkOrderRepository();
            var repairTeamRepo = new DummyRepairTeamRepository();

            kernel.Bind<IWorkOrderRepository>().ToConstant(workOrderRepo);
            kernel.Bind<IRepairTeamRepository>().ToConstant(repairTeamRepo);

            kernel.Bind<IWorkOrderService>().To<WorkOrderService>();
            kernel.Bind<IRepairTeamService>().To<RepairTeamService>();            

            var workOrderService = kernel.Get<IWorkOrderService>();
            var repairTeamService = kernel.Get<IRepairTeamService>();

            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("workOrderRepo", workOrderRepo);
            ScenarioContext.Current.Add("workOrderService", workOrderService);
            ScenarioContext.Current.Add("repairTeamRepo", repairTeamRepo);
            ScenarioContext.Current.Add("repairTeamService", repairTeamService);

        }
    }
}
