using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using RoadMaintenance.FaultRepair.Services;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos;
using Ninject;

namespace RoadMaintenance.FaultRepair.Application
{
    // Class representing a work order handler in the application layer

    public class WorkOrderHandler
    {
        public WorkOrderHandler()
        {
        }

        public string CreateWorkOrder(string       description, 
                                      List<string> tasks,
                                      List<Tuple<string, int>> equipment,
                                      List<Tuple<string, double, MeasurementType>> materials)
        {
            // Use Ninject to inject the work order repository

            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IWorkOrderRepository woRepo = kernel.Get<IWorkOrderRepository>();
            WorkOrderService wos = new WorkOrderService(woRepo);

            return wos.CreateWorkOrder(description, tasks, equipment, materials);
        }
    }
}
