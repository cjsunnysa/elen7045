using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;
using RoadMaintenance.FaultRepair.Repos.Interfaces;
using RoadMaintenance.SharedKernel.Repos;

namespace RoadMaintenance.FaultRepair.Repos
{
    public class DummyWorkOrderRepository : DummyRepo<string, WorkOrder>, IWorkOrderRepository
    {
        
        public DummyWorkOrderRepository()
            : base()
        {            
        }

        public DummyWorkOrderRepository(IEnumerable<WorkOrder> data)
            : base(data)
        {
                        
        }

        public void PopulateDummyData()
        {
            // Populate the dummy data

            var wob = new WorkOrderBuilder("Potholes at West Street, JHB");
            wob.AddTask("Fix Pothole");
            wob.AddTask("Repaint road markings");
            wob.AddMaterial("Bitumen", 100, MeasurementType.Kg);
            wob.AddMaterial("White Paint", 100, MeasurementType.Liters);
            wob.AddEquipment("Shovel", 5);
            wob.AddEquipment("Steamroller", 1);            
            this.Save(wob.GetResult());

            wob = new WorkOrderBuilder("Robot hit by minibus taxi in Soweto");
            wob.AddTask("Remove broken robot");
            wob.AddTask("Erect new robot");
            wob.AddTask("Connect robot wirings");
            wob.AddMaterial("Wires", 100, MeasurementType.Items);
            wob.AddMaterial("Cement", 100, MeasurementType.Kg);
            wob.AddEquipment("Cement Mixer", 1);
            wob.AddEquipment("Pliers", 2);
            wob.AddEquipment("Shovel", 10);
            this.Save(wob.GetResult());            

            wob = new WorkOrderBuilder("Drain flooded at Illovo");
            wob.AddTask("Pump water out of drain");
            wob.AddEquipment("Pump", 1);
            this.Save(wob.GetResult());            
        }        


        public List<WorkOrder> GetWorkOrdersByStatus(WorkOrderStatus status)
        {
            var results = entityMap.Values.Where(wo => wo.Status == status);
            return new List<WorkOrder>(results);
        }

        public List<WorkOrder> GetWorkOrdersByFault(int faultID)
        {
            var results = entityMap.Values.Where(wo => wo.FaultID == faultID);
            return new List<WorkOrder>(results);
        }

        public List<WorkOrder> GetAllWorkOrders()
        {
            return entityMap.Values.ToList();
        }         

    }
}
