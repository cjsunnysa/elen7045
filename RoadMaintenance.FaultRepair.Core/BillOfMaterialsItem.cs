using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.FaultRepair.Core
{
    public enum MeasurementType { Items, Kg, Liters};
    public class BillOfMaterialsItem
    {
        public string Description { get; set; }
        public double Quantity { get; set; }
        public MeasurementType QuantityType { get; set; }

        public BillOfMaterialsItem()
        {
            this.Description = string.Empty;
            this.Quantity = 0.0;
            this.QuantityType = MeasurementType.Items;
        }

        public BillOfMaterialsItem(string description, double quantity, MeasurementType quantityType)
        {
            this.Description = description;
            this.Quantity = quantity;
            this.QuantityType = quantityType;
        }




    }
}
