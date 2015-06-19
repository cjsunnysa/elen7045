using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public enum WorkOrderStatus {Created, Issued, Scheduled, Verified, Closed};

    public class WorkOrder
    {
        // Private members

        private string id;
        private string description;
        private WorkOrderStatus status;
        private DateTime creationDate;
        private string department;
        private int faultID;

        private List<WorkOrderTask> tasks;
        private List<BillOfMaterialsItem> billOfMaterials;
        private List<Equipment> equipment;

        // Properties
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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

        public WorkOrder()
        {
            tasks = new List<WorkOrderTask>();
            billOfMaterials = new List<BillOfMaterialsItem>();
            equipment = new List<Equipment>();
        }

        public WorkOrder(string id, WorkOrderStatus status, DateTime creationDate, string department, int faultID)
            : this()
        {
            this.id = id;
            this.status = status;
            this.creationDate = creationDate;
            this.department = department;
            this.faultID = faultID;
        }
    }
}
