using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Services
{
    public class WorkOrderService
    {
        private readonly IWorkOrderRepository workOrderRepo;

        public WorkOrderService(IWorkOrderRepository workOrderRepo) 
        {
            this.workOrderRepo = workOrderRepo;
        }

        public string CreateWorkOrder(string       description, 
                                      List<string> tasks,
                                      List<Tuple<string, int>> equipment,
                                      List<Tuple<string, double, MeasurementType>> materials)
        {
            // Use factory (builder) to create new work order
            WorkOrderBuilder wob = new WorkOrderBuilder(description);
            
            // Set tasks
            foreach(var task in tasks)
            {
                wob.AddTask(task);
            }

            // Set equipment
            foreach(var tool in equipment)
            {
                wob.AddEquipment(tool.Item1, tool.Item2);
            }

            // Set material
            foreach(var material in materials)
            {
                wob.AddMaterial(material.Item1, material.Item2, material.Item3);
            }            

            WorkOrder newWO = wob.GetResult();

            // Insert new work order into repo

            workOrderRepo.InsertWorkOrder(newWO);

            return newWO.ID;
        }

        public void AssignWorkOrderToFault (string workOrderID, int faultID)
        {
            // Get existing work order from repository
            WorkOrder wo = workOrderRepo.GetWorkOrderByID(workOrderID);

            // Assign fault
            wo.FaultID = faultID;

            // Update repo with new details
            workOrderRepo.UpdateWorkOrder(wo);
        }
    }
}
