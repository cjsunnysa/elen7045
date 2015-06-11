using System.Collections.Generic;
using RoadMaintenance.DataService.DTO;

namespace RoadMaintenance.DataService.Interfaces
{
    public interface IRoadMaintenanceDatasource
    {
        IEnumerable<FaultDTO> GetFaults();
        IEnumerable<FaultTypeDTO> GetFaultTypes();
        IEnumerable<FaultStatusDTO> GetFaultStatuses();
    }
}