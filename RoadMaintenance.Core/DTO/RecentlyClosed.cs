using System;

namespace RoadMaintenance.FaultLogging.Core.DTO
{
    public class RecentlyClosed
    {
        public RecentlyClosed()
        {
            Today = DateTime.Today;
            PeriodDays = 30;
        }
        
        public DateTime ClosedPeriodStartDate
        {
            get
            {
                var completedPeriodDays = PeriodDays > 0
                                          ? PeriodDays * -1
                                          : PeriodDays;

                return Today.AddDays(completedPeriodDays);
            }
        }
        
        public DateTime Today { get; set; }
        public int PeriodDays { get; set; }
    }
}