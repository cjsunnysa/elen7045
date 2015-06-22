using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using RoadMaintenance.FaultRepair.Repos;

namespace RoadMaintenance.FaultRepair.Application
{
    public class DependencyInjectionBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IWorkOrderRepository>().To<DummyWorkOrderRepository>();
        }
    }
}
