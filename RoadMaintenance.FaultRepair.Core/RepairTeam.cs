using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultRepair.Core
{
    public class RepairTeam : Entity<string>
    {
        protected List<ScheduleEntry> schedule;
        public IEnumerable<ScheduleEntry> Schedule
        {
            get { return schedule; }
        }       

        public RepairTeam(string id, IEnumerable<ScheduleEntry> scheduleEntries )
            :base(id)
        {
                
        }

        public bool Assign(WorkOrder workOrder, DateTime workOrderStartTime)
        {            
            int existingIndex = schedule.FindIndex(entry => entry.WorkOrderId == workOrder.Id);
            ScheduleEntry existingItem = null;
            if (existingIndex != -1)
            {
                existingItem = schedule[existingIndex];
                schedule.RemoveAt(existingIndex);
            }

            var scheduleEntry = new ScheduleEntry(workOrder.Id, workOrderStartTime, workOrder.Duration);
            if (
                schedule.Any(
                    existingEntry =>
                        (scheduleEntry.StartTime > existingEntry.StartTime &&
                         scheduleEntry.StartTime < existingEntry.EndTime) ||
                        (scheduleEntry.EndTime > existingEntry.StartTime &&
                         scheduleEntry.EndTime < existingEntry.EndTime) ||
                        (existingEntry.StartTime > scheduleEntry.StartTime &&
                        existingEntry.EndTime < scheduleEntry.EndTime)))
            {
                if (existingIndex != -1)
                    schedule.Insert(existingIndex, existingItem);
                return false;
            }


            var nextEntry = schedule.FirstOrDefault(existingEntry => scheduleEntry.EndTime <= existingEntry.StartTime);
            if (nextEntry == null)
                schedule.Add(scheduleEntry);
            else
                schedule.Insert(schedule.IndexOf(nextEntry), scheduleEntry);

            return true;
        }

        public bool UnassignWorkOrder(string workOrderId)
        {
            var scheduleEntry = schedule.FirstOrDefault(entry => entry.WorkOrderId == workOrderId);
            if (scheduleEntry == null)
                return false;

            return schedule.Remove(scheduleEntry);
        }
    }
}
