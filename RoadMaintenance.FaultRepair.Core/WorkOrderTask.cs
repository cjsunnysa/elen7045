using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public enum WorkOrderTaskStatus { Created, Completed };

    public class WorkOrderTask
    {
        private WorkOrderTaskStatus status;
        private string description;

        public WorkOrderTask()
        {
            status = WorkOrderTaskStatus.Created;
            description = string.Empty;
        }

        public WorkOrderTask(WorkOrderTaskStatus status, string description)
        {
            this.status = status;
            this.description = description;
        }
    }
}
