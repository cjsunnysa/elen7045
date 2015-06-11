using System.Linq;
using RoadMaintenance.DataService.DTO;
using RoadMaintenance.DataService.Interfaces;

namespace RoadMaintenance.DataService
{
    public class FaultDatabaseRepository : IFaultRepository
    {
        private readonly IRoadMaintenanceDatasource _dbContext;

        public FaultDatabaseRepository(IRoadMaintenanceDatasource context)
        {
            _dbContext = context;
        }
        
        public FaultDTO SelectById(int id)
        {
            return _dbContext.GetFaults().SingleOrDefault(fault => fault.Id == id);
        }

        public FaultDTO[] SelectAll()
        {
            return _dbContext.GetFaults().ToArray();
        }

        public FaultDTO[] SelectByFaultSearch(FaultSearchDTO faultSearch)
        {
            var street = faultSearch.Street;
            var suburb = faultSearch.Suburb;
            var postCode = faultSearch.PostCode;
            
            return
                _dbContext.GetFaults()
                    .Where(fault => 
                        (string.IsNullOrEmpty(street)   || fault.Street.ToLower().Contains(street.ToLower()) ) && 
                        (string.IsNullOrEmpty(suburb)   || fault.Suburb.ToLower().Contains(suburb.ToLower()) ) && 
                        (string.IsNullOrEmpty(postCode) || fault.PostCode.Contains(postCode) ) 
                    ).ToArray();
        }
    }
}