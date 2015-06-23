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
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.SharedKernel.Repos;
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

            kernel.Bind<IWorkOrderRepository>().ToConstant(workOrderRepo).InSingletonScope();
            kernel.Bind<IRepairTeamRepository>().ToConstant(repairTeamRepo).InSingletonScope();

            kernel.Bind<IWorkOrderService>().To<WorkOrderService>();
            kernel.Bind<IRepairTeamService>().To<RepairTeamService>();            

            var workOrderService = kernel.Get<IWorkOrderService>();
            var repairTeamService = kernel.Get<IRepairTeamService>();

            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("workOrderRepo", workOrderRepo);
            ScenarioContext.Current.Add("workOrderService", workOrderService);
            ScenarioContext.Current.Add("repairTeamRepo", repairTeamRepo);
            ScenarioContext.Current.Add("repairTeamService", repairTeamService);

            setupMethodAccessRepo(kernel);

        }

        private void setupMethodAccessRepo(StandardKernel kernel)
        {
            var methodAccessRepo = kernel.Get<IMethodAccessRepository>();

            methodAccessRepo.Save(new MethodAccess("RepairTeamService.GetRepairTeam", "Dispatcher", "Supervisor"));
            methodAccessRepo.Save(new MethodAccess("RepairTeamService.GetRepairTeams", "Dispatcher", "Supervisor"));
            methodAccessRepo.Save(new MethodAccess("RepairTeamService.AssignWorkOrder", "Dispatcher", "Supervisor"));
            methodAccessRepo.Save(new MethodAccess("RepairTeamService.UnassignWorkOrder", "Dispatcher", "Supervisor"));
            methodAccessRepo.Save(new MethodAccess("RepairTeamService.ReassignWorkOrder", "Dispatcher", "Supervisor"));
            
            methodAccessRepo.Save(new MethodAccess("WorkOrderService.GetUnscheduledWorkOrders", "Dispatcher", "Supervisor"));
        }

        [Given(@"I am a ""(.*)""")]
        public void GivenIAmA(string p0)
        {
            TestKernelBootstrapper.SetupUser(p0);
        }

    }
}
