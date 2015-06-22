using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class Equipment
    {
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Equipment()
        {
            Description = string.Empty;
            Quantity = 0;
        }

        public Equipment(string description, int quantity)
        {
            this.Description = description;
            this.Quantity = quantity;
        }
    }
}
