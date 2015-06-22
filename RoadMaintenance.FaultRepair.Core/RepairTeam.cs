using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class RepairTeam
    {
        public string Id { get; set; }
        public List<ScheduleEntry> Schedule { get; set; }

        public bool Assign(WorkOrder workOrder, DateTime workOrderStartTime)
        {            
            int existingIndex = Schedule.FindIndex(entry => entry.WorkOrderId == workOrder.ID);
            ScheduleEntry existingItem = null;
            if (existingIndex != -1)
            {
                existingItem = Schedule[existingIndex];
                Schedule.RemoveAt(existingIndex);
            }

            var scheduleEntry = new ScheduleEntry(workOrder.ID, workOrderStartTime, workOrder.Duration);
            if (
                Schedule.Any(
                    existingEntry =>
                        (scheduleEntry.StartTime > existingEntry.StartTime &&
                         scheduleEntry.StartTime < existingEntry.EndTime) ||
                        (scheduleEntry.EndTime > existingEntry.StartTime &&
                         scheduleEntry.EndTime < existingEntry.EndTime) ||
                        (existingEntry.StartTime > scheduleEntry.StartTime &&
                        existingEntry.EndTime < scheduleEntry.EndTime)))
            {
                if (existingIndex != -1)
                    Schedule.Insert(existingIndex, existingItem);
                return false;
            }


            var nextEntry = Schedule.FirstOrDefault(existingEntry => scheduleEntry.EndTime <= existingEntry.StartTime);
            if (nextEntry == null)
                Schedule.Add(scheduleEntry);
            else
                Schedule.Insert(Schedule.IndexOf(nextEntry), scheduleEntry);

            return true;
        }

        public bool UnassignWorkOrder(string workOrderId)
        {
            var scheduleEntry = Schedule.FirstOrDefault(entry => entry.WorkOrderId == workOrderId);
            if (scheduleEntry == null)
                return false;

            return Schedule.Remove(scheduleEntry);
        }
    }
}
