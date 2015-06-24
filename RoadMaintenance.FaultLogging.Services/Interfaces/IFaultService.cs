using System;
using System.Collections.Generic;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Services.Response;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services.Interfaces
{
    public interface IFaultService
    {
        Type GetType(string description);

        string GetStatusDescription(Status status);

        FaultDetailsView Find(Guid id);

        IEnumerable<FaultDetailsView> Search(FaultSearchRequest request);

        Guid CreateFault(CreateFaultRequest request);

        void UpdateGpsCoordinates(UpdateGpsCoordinatesRequest request);

        void UpdateAddress(UpdateAddressRequest request);
    }
}