using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public class Equipment
    {
        private string description;

        public Equipment()
        {
            description = string.Empty;
        }

        public Equipment(string description)
        {
            this.description = description;
        }
    }
}
