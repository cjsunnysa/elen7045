using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class ScheduleEntry
    {
        public readonly string WorkOrderId;

        private const int DayStartTime = 8;
        private const int DayEndTime = 16;

        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public readonly int Duration;

        protected ScheduleEntry(string workOrderId, DateTime startTime, DateTime endTime, int duration)
        {
            if (startTime.Hour < DayStartTime || startTime.Hour >= DayEndTime)
                throw new Exception("Invalid Time Supplied");

            if (startTime.DayOfWeek == DayOfWeek.Saturday || startTime.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception("Invalid Start Date Supplied");

            if (endTime.DayOfWeek == DayOfWeek.Saturday || endTime.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception("Invalid End Date Supplied");

            WorkOrderId = workOrderId;
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;

        }
                
        public ScheduleEntry(string workOrderId, DateTime startTime, int duration)
            :this(workOrderId, startTime, getEndTime(startTime, duration), duration)
        {                        
        }

        public ScheduleEntry(string workOrderId, DateTime startTime, DateTime endTime)
            :this(workOrderId, startTime, endTime, getDuration(startTime, endTime))
        {            
        }

        private static DateTime getEndTime(DateTime startTime, int duration)
        {
            var endTime = startTime;
            var dayLength = DayEndTime - DayStartTime;

            var days = duration / (dayLength);
            for (int i = 0; i < days; i++)
                endTime = incrementDay(endTime);

            var remainingDuration = duration - days * dayLength;
            var availableTimeLeftInDay = DayEndTime - endTime.Hour;

            if (availableTimeLeftInDay < remainingDuration)
            {
                remainingDuration -= availableTimeLeftInDay;
                endTime = incrementDay(endTime);
                endTime = endTime.AddDays(DayStartTime - endTime.Hour);
            }

            return endTime.AddHours(remainingDuration);           
        }

        private static DateTime incrementDay(DateTime date)
        {
            for (date = date.AddDays(1);
                date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                date = date.AddDays(1));

            return date;
        }

        private static int getDuration(DateTime startTime, DateTime endTime)
        {
            if (startTime.DayOfYear == endTime.DayOfYear || startTime.Year == endTime.Year)
                return endTime.Hour - startTime.Hour;
            
            var dayLength = DayEndTime - DayStartTime;

            var duration = DayEndTime - startTime.Hour;

            for (var workingTime = incrementDay(startTime);
                workingTime.Year <= endTime.Year && workingTime.DayOfYear < endTime.DayOfYear;
                workingTime = incrementDay(workingTime))
            {
                duration += dayLength;
            }            

            duration += endTime.Hour - DayStartTime;

            return duration;
        }
    }
}
