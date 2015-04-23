using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RoadMaintenance.DataService;
using RoadMaintenance.DataService.DTO;
using RoadMaintenance.DataService.Interfaces;
using RoadMaintenance.MVC.Models;
using RoadMaintenance.MVC.Models.Converters;

namespace RoadMaintenance.MVC.Controllers
{
    public class FaultsController : ApiController
    {
        private readonly IFaultRepository _faultRepo = new FaultDatabaseRepository();
        
        // GET api/faults
        public FaultModel[] Get()
        {
            return _faultRepo.SelectAll().Select(fault => fault.ToModel()).ToArray();
        }

        // GET api/faults/5
        public FaultModel[] Get(int id)
        {
            return new []{ _faultRepo.SelectById(id).ToModel() };
        }

        // POST api/faults
        public void Post([FromBody]string value)
        {
        }

        // PUT api/faults/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/faults/5
        public void Delete(int id)
        {
        }
    }
}
