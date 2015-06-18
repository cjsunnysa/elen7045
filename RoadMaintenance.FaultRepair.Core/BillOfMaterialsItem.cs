using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    enum MeasurementType { Amount, WeightInKG, VolumeInLiter};
    class BillOfMaterialsItem
    {
        private string description;
        private double quantity;
        private MeasurementType quantityType;
    }
}
