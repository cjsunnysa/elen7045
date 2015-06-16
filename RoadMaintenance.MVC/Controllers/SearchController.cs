using System.Web.Mvc;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos.Interfaces;

namespace RoadMaintenance.MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly IFaultRepository _repository;

        public SearchController(IFaultRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SearchResults(SearchDTO search)
        {
            var results = _repository.GetFaultsBy(search);
            
            return View(results);
        }
    }
}
