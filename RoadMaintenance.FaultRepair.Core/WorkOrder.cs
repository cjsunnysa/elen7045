using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public enum WorkOrderStatus {Creating, Created, Issued, Scheduled, AwaitingVerification, Verified, Closed};

    public class WorkOrder
    {
        // Private members

        private static int idSequence = 0;

        private string id;        
        private string description;
        private WorkOrderStatus status;
        private DateTime creationDate;
        private string department;
        private int faultID;

        private List<WorkOrderTask> tasks;
        private List<BillOfMaterialsItem> billOfMaterials;
        private List<Equipment> equipment;

        private static string GenerateID()
        {
            ++idSequence;
            string newID = string.Format("WO{0}", idSequence);
            return newID;
        }

        // Properties
        public string ID
        {
            get
            {
                return id;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public WorkOrderStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }

        public int FaultID
        {
            get
            {
                return faultID;
            }
            set
            {
                faultID = value;
            }
        }

        public List<WorkOrderTask> Tasks
        {
            get
            {
                return tasks;
            }
        }

        public List<BillOfMaterialsItem> BillOfMaterials
        {
            get
            {
                return billOfMaterials;
            }
        }

        public List<Equipment> Equipment
        {
            get
            {
                return equipment;
            }
        }

        public int Duration { get; set; }

        public WorkOrder(string id)
        {
            this.id           = id;
            description  = string.Empty;
            status       = WorkOrderStatus.Created;
            creationDate = DateTime.Now;
            department   = string.Empty;
            faultID      = 0;

            tasks           = new List<WorkOrderTask>();
            billOfMaterials = new List<BillOfMaterialsItem>();
            equipment       = new List<Equipment>();
        }

        public WorkOrder()
            : this(GenerateID())
        {
            
        }

        public WorkOrder(WorkOrderStatus status, DateTime creationDate, string department, int faultID)
            : this()
        {            
            this.status       = status;
            this.creationDate = creationDate;
            this.department   = department;
            this.faultID      = faultID;
        }
        
    }
}
