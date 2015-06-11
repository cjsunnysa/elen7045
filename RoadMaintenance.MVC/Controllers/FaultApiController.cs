using System.Web.Http;
using RoadMaintenance.DataService.DTO;
using RoadMaintenance.DataService.Interfaces;

namespace RoadMaintenance.MVC.Controllers
{
    public class FaultApiController : ApiController
    {
        private readonly IFaultRepository _repo;

        public FaultApiController(IFaultRepository repository)
        {
            _repo = repository;
        }

        public FaultDTO[] Get()
        {
            return _repo.SelectAll();
        }

        public FaultDTO Get(int id)
        {
            return _repo.SelectById(id);
        }

        [HttpPost]
        public FaultDTO[] SearchByObject([FromBody] FaultSearchDTO searchDTO)
        {
            return _repo.SelectByFaultSearch(searchDTO);
        }
    }
}
