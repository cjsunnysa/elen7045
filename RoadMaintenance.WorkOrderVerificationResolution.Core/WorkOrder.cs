using RoadMaintenance.SharedKernel.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.WorkOrderVerificationResolution.Core
{
    public class WorkOrder : Entity<string>
    {        
        public Status Status { get; set; }
        public String FaultId { get; set; }
        public Priority Priority { get; set; }

        public WorkOrder(string id)
            : base(id)
        {
            
        }

        public WorkOrder(string id, Status status, string faultId, Priority priority)
            : this(id)
        {            
            Status = status;
            FaultId = faultId;
            Priority = priority;
        }
    }

    public enum Priority
    {
        Low = 1,
        Normal = 2,
        High = 3,
    }

    public enum Status
    {
        Issued,
        Scheduled,
        Completed,
        Satisfactory,
        Unsatisfactory,
        AwaitingVerification
    };

}
