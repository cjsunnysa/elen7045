using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using FaultLogging.Core.Interfaces;
using FaultLogging.Core.Shared;


namespace FaultLogging.Core.Model
{
    public class SearchDTO
    {
        public int? TypeId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Suburb { get; set; }
    }
}
