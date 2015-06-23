using System;
using RoadMaintenance.FaultLogging.Core.Model;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Interfaces
{
    public interface IFaultFactory
    {
        Call CreateCallReference(int operatorId, DateTime date);
        Fault CreateFault(string streetName, string crossStreet, string suburb, Type type);
    }
}