using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class ScheduleBlock
    {
        private const int DayStartTime = 8;
        private const int DayEndTime = 16;

        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public readonly int Duration;

        public ScheduleBlock(DateTime startTime, int duration)
        {
            if (startTime.Hour < DayStartTime || startTime.Hour >= DayEndTime)
                throw  new Exception("Invalid Time Supplied");

            if (startTime.DayOfWeek == DayOfWeek.Saturday || startTime.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception("Invalid date suuplied");

            StartTime = startTime;            
            Duration = duration;

            EndTime = getEndTime();
        }

        private DateTime getEndTime()
        {
            var endTime = StartTime;
            var dayLength = DayEndTime - DayStartTime;

            var days = Duration/(dayLength);
            for (int i = 0; i < days; i++)
                endTime = incrementDay(endTime);

            var remainingDuration = Duration - days*dayLength;
            var availableTimeLeftInDay = DayEndTime - endTime.Hour;

            if (availableTimeLeftInDay < remainingDuration)
            {
                remainingDuration -= availableTimeLeftInDay;
                endTime = incrementDay(endTime);
                endTime = endTime.AddDays(DayStartTime - endTime.Hour);
            }

            return endTime.AddHours(remainingDuration);           
        }

        private DateTime incrementDay(DateTime date)
        {
            for (date = date.AddDays(1);
                date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                date = date.AddDays(1));

            return date;
        }

        public ScheduleBlock(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Duration = getDuration();
        }

        private int getDuration()
        {
            if (StartTime.DayOfYear == EndTime.DayOfYear || StartTime.Year == EndTime.Year)
                return EndTime.Hour - StartTime.Hour;
            
            var dayLength = DayEndTime - DayStartTime;

            var duration = DayEndTime - StartTime.Hour;

            for (var workingTime = incrementDay(StartTime);
                workingTime.Year <= EndTime.Year && workingTime.DayOfYear < EndTime.DayOfYear;
                workingTime = incrementDay(workingTime))
            {
                duration += dayLength;
            }            

            duration += EndTime.Hour - DayStartTime;

            return duration;
        }
    }
}
