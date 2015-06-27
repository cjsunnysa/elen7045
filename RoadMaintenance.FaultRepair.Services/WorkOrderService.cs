using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Repos;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.SharedKernel.Services;

namespace RoadMaintenance.FaultRepair.Services
{
    public interface IWorkOrderService
    {
        string CreateWorkOrder(string       description, 
            List<string> tasks,
            List<Tuple<string, int>> equipment,
            List<Tuple<string, double, MeasurementType>> materials);

        void AmendWorkOrder(string workOrderID,
            List<string> tasks,
            List<Tuple<string, int>> equipment,
            List<Tuple<string, double, MeasurementType>> materials);

        void AssignWorkOrderToFault (string workOrderID, int faultID);
        void UpdateWorkOrderStatus(string workOrderID, WorkOrderStatus newStatus);

        void GetWorkOrderDetails(string workOrderID,
            out string description,
            out WorkOrderStatus status,
            out DateTime creationDate,
            out string department,
            out int faultID,
            out List<string> tasks,
            out List<Tuple<string, int>> equipment,
            out List<Tuple<string, double, MeasurementType>> materials);

        IEnumerable<WorkOrderInfo> GetUnscheduledWorkOrders();
    }

    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository workOrderRepo;

        public WorkOrderService(IWorkOrderRepository workOrderRepo)
        {
            this.workOrderRepo = workOrderRepo;
        }

        [MethodSecurity]
        public string CreateWorkOrder(string       description, 
                                      List<string> tasks,
                                      List<Tuple<string, int>> equipment,
                                      List<Tuple<string, double, MeasurementType>> materials)
        {
            // Use factory (builder) to create new work order
            WorkOrderBuilder wob = new WorkOrderBuilder(description);
            
            // Set tasks
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    wob.AddTask(task);
                }
            }

            // Set equipment
            if (equipment != null)
            {
                foreach (var tool in equipment)
                {
                    wob.AddEquipment(tool.Item1, tool.Item2);
                }
            }

            // Set material
            if (materials != null)
            {
                foreach (var material in materials)
                {
                    wob.AddMaterial(material.Item1, material.Item2, material.Item3);
                }
            }

            WorkOrder newWO = wob.GetResult();

            // Insert new work order into repo

            workOrderRepo.InsertWorkOrder(newWO);

            return newWO.ID;
        }

        [MethodSecurity]
        public void AmendWorkOrder(string workOrderID,
                                   List<string> tasks,
                                   List<Tuple<string, int>> equipment,
                                   List<Tuple<string, double, MeasurementType>> materials)
        {
            // Get existing work order from repository
            WorkOrder wo = workOrderRepo.GetWorkOrderByID(workOrderID);

            WorkOrderBuilder wob = new WorkOrderBuilder(wo);

            // Set tasks
            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    wob.AddTask(task);
                }
            }

            // Set equipment
            if (equipment != null)
            {
                foreach (var tool in equipment)
                {
                    wob.AddEquipment(tool.Item1, tool.Item2);
                }
            }

            // Set material
            if (materials != null)
            {
                foreach (var material in materials)
                {
                    wob.AddMaterial(material.Item1, material.Item2, material.Item3);
                }
            }

            WorkOrder existingWO = wob.GetResult();

            // Update work order in repo

            workOrderRepo.UpdateWorkOrder(existingWO);
        }

        [MethodSecurity]
        public void AssignWorkOrderToFault (string workOrderID, int faultID)
        {
            // Get existing work order from repository
            WorkOrder wo = workOrderRepo.GetWorkOrderByID(workOrderID);

            // Assign fault
            wo.FaultID = faultID;

            // Update repo with new details
            workOrderRepo.UpdateWorkOrder(wo);
        }

        [MethodSecurity]
        public void UpdateWorkOrderStatus(string workOrderID, WorkOrderStatus newStatus)
        {
            // Get existing work order from repository
            WorkOrder wo = workOrderRepo.GetWorkOrderByID(workOrderID);

            // Update the status
            wo.Status = newStatus;

            // Update repo with new details
            workOrderRepo.UpdateWorkOrder(wo);
        }

        public void GetWorkOrderDetails(string workOrderID,
                                        out string description,
                                        out WorkOrderStatus status,
                                        out DateTime creationDate,
                                        out string department,
                                        out int faultID,
                                        out List<string> tasks,
                                        out List<Tuple<string, int>> equipment,
                                        out List<Tuple<string, double, MeasurementType>> materials)
        {
            // Get existing work order from repository
            WorkOrder wo = workOrderRepo.GetWorkOrderByID(workOrderID);

            description = wo.Description;
            status = wo.Status;
            creationDate = wo.CreationDate;
            department = wo.Department;
            faultID = wo.FaultID;

            tasks = new List<string>();
            foreach(WorkOrderTask wot in wo.Tasks)
            {
                tasks.Add(wot.Description);
            }

            equipment = new List<Tuple<string, int>>();
            foreach(Equipment e in wo.Equipment)
            {
                equipment.Add(new Tuple<string, int>(e.Description, e.Quantity));
            }

            materials = new List<Tuple<string, double, MeasurementType>>();
            foreach(BillOfMaterialsItem item in wo.BillOfMaterials)
            {
                materials.Add(new Tuple<string, double, MeasurementType>(item.Description, item.Quantity, item.QuantityType));
            }
        }

        public IEnumerable<WorkOrderInfo> GetUnscheduledWorkOrders()
        {
            return
                workOrderRepo.GetWorkOrdersByStatus(WorkOrderStatus.Issued)
                    .Select(workOrder => new WorkOrderInfo(workOrder));

        }
    }
}
