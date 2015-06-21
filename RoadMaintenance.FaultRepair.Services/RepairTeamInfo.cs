using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultRepair.Core;

namespace RoadMaintenance.FaultRepair.Services
{
    public class RepairTeamInfo
    {
        public string Id { get; set; }
        public IEnumerable<ScheduleEntry> Schedule { get; set; }

        public RepairTeamInfo(RepairTeam team)
        {
            Id = team.Id;
            Schedule = team.Schedule;
        }        
    }
}
