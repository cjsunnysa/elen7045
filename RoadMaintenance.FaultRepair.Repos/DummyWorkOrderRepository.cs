using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Repos
{
    public class DummyWorkOrderRepository : IWorkOrderRepository
    {
        private List<WorkOrder> dummyData;

        public DummyWorkOrderRepository()
        {
            dummyData = new List<WorkOrder>();

            // Populate the dummy data

            var wob = new WorkOrderBuilder("Potholes at West Street, JHB");
            wob.AddTask("Fix Pothole");
            wob.AddTask("Repaint road markings");
            wob.AddMaterial("Bitumen", 100, MeasurementType.WeightInKG);
            wob.AddMaterial("White Paint", 100, MeasurementType.VolumeInLiter);
            wob.AddEquipment("Shovel", 5);
            wob.AddEquipment("Steamroller", 1);
            dummyData.Add(wob.GetResult());

            wob = new WorkOrderBuilder("Robot hit by minibus taxi in Soweto");
            wob.AddTask("Remove broken robot");
            wob.AddTask("Erect new robot");
            wob.AddTask("Connect robot wirings");
            wob.AddMaterial("Wires", 100, MeasurementType.Amount);
            wob.AddMaterial("Cement", 100, MeasurementType.WeightInKG);
            wob.AddEquipment("Cement Mixer", 1);
            wob.AddEquipment("Pliers", 2);
            wob.AddEquipment("Shovel", 10);
            dummyData.Add(wob.GetResult());

            wob = new WorkOrderBuilder("Drain flooded at Illovo");
            wob.AddTask("Pump water out of drain");
            wob.AddEquipment("Pump", 1);
            dummyData.Add(wob.GetResult());

        }

        public WorkOrder GetWorkOrderByID(string id)
        {
            var result = dummyData.First(wo => wo.ID == id);
            return result;
        }


        public List<WorkOrder> GetWorkOrdersByStatus(WorkOrderStatus status)
        {
            var results = dummyData.Where(wo => wo.Status == status);
            return new List<WorkOrder>(results);
        }

        public List<WorkOrder> GetWorkOrdersByFault(int faultID)
        {
            var results = dummyData.Where(wo => wo.FaultID == faultID);
            return new List<WorkOrder>(results);
        }

        public void InsertWorkOrder(WorkOrder wo)
        {
            dummyData.Add(wo);
        }

        public void UpdateWorkOrder(WorkOrder wo)
        {
            dummyData[dummyData.FindIndex(ind => ind.ID == wo.ID)] = wo;
        }

        public void DeleteWorkOrder(WorkOrder wo)
        {
            dummyData.Remove(wo);
        }


    }
}
