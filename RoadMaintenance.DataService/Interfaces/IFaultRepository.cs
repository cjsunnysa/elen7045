using RoadMaintenance.DataService.DTO;

namespace RoadMaintenance.DataService.Interfaces
{
    public interface IFaultRepository : IRepository<FaultDTO>
    {
        FaultDTO[] SelectByFaultSearch(FaultSearchDTO faultSearch);
    }
}