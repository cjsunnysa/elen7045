using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    enum WorkOrderStatus {Created, Verified};

    class WorkOrder
    {
        private int id;
        private WorkOrderStatus status;
        private DateTime creationDate;
        private string Department;

    }
}
