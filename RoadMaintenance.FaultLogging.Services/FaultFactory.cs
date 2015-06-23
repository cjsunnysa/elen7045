using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services.Interfaces;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services
{
    public class FaultFactory : IFaultFactory
    {
        public Call CreateCallReference(int operatorId, DateTime date)
        {
            return Call.Create(operatorId, date);
        }

        public Fault CreateFault(string streetName, string crossStreet, string suburb, Type type)
        {
            return Fault.Create(type, Status.PendingInvestigation, new Address(streetName, crossStreet, suburb, ""));
        }
    }
}
