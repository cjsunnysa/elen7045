using System;
using System.Linq;
using RoadMaintenance.DataService.Datastore;
using RoadMaintenance.DataService.DTO;
using RoadMaintenance.DataService.Interfaces;

namespace RoadMaintenance.DataService
{
    public class FaultDatabaseRepository : IFaultRepository
    {
        public FaultDTO SelectById(int id)
        {
            return RoadMaintenanceDatabase.GetAllFaults().SingleOrDefault(fault => fault.Id == id);
        }

        public FaultDTO[] SelectAll()
        {
            return RoadMaintenanceDatabase.GetAllFaults();
        }

        public FaultDTO[] SelectByStatusId(int statusId)
        {
            return RoadMaintenanceDatabase.GetAllFaults().Where(fault => fault.StatusId == statusId).ToArray();
        }

        public FaultDTO[] SelectByAddressProximity(AddressDTO address)
        {
            return RoadMaintenanceDatabase.GetAllFaults().Where(fault => fault.Address.Suburb.Equals(address.Suburb, StringComparison.CurrentCultureIgnoreCase)).ToArray();
        }
    }
}