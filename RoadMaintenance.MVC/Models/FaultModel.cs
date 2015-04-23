using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadMaintenance.MVC.Models
{
    public class FaultModel
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
    }
}