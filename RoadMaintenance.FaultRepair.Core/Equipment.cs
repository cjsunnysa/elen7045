using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class Equipment
    {
        private string description;
        private int quantity;

        public Equipment()
        {
            description = string.Empty;
            quantity = 0;
        }

        public Equipment(string description, int quantity)
        {
            this.description = description;
            this.quantity = quantity;
        }
    }
}
