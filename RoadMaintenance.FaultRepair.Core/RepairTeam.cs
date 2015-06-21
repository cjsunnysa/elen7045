using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class RepairTeam
    {
        public string Id { get; set; }
        public IEnumerable<ScheduleEntry> Schedule { get; set; }
    }
}
