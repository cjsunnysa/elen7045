using RoadMaintenance.DataService.DTO;

namespace RoadMaintenance.DataService.Interfaces
{
    public interface IFaultRepository : IRepository<FaultDTO>
    {
        FaultDTO[] SelectByStatusId(int statusId);
        FaultDTO[] SelectByAddressProximity(AddressDTO address);
    }
}