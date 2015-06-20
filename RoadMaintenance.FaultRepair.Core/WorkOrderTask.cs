using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public enum WorkOrderTaskStatus { Created, Completed };

    public class WorkOrderTask
    {
        public WorkOrderTaskStatus Status { get; set; }
        public string Description { get; set; }

        public WorkOrderTask()
        {
            Status = WorkOrderTaskStatus.Created;
            Description = string.Empty;
        }

        public WorkOrderTask(WorkOrderTaskStatus status, string description)
        {
            this.Status = status;
            this.Description = description;
        }
    }
}
