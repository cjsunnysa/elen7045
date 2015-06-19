using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public enum MeasurementType { Amount, WeightInKG, VolumeInLiter};
    public class BillOfMaterialsItem
    {
        private string description;
        private double quantity;
        private MeasurementType quantityType;

        public BillOfMaterialsItem()
        {
            this.description = string.Empty;
            this.quantity = 0.0;
            this.quantityType = MeasurementType.Amount;
        }

        public BillOfMaterialsItem(string description, double quantity, MeasurementType quantityType)
        {
            this.description = description;
            this.quantity = quantity;
            this.quantityType = quantityType;
        }




    }
}
