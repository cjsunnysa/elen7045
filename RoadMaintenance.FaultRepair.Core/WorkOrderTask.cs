using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    enum WorkOrderTaskStatus { Created, Verified };

    class WorkOrderTask
    {
        private WorkOrderTaskStatus status;
        private string Description;
    }
}
