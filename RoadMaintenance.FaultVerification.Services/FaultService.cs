﻿using RoadMaintenance.FaultVerification.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadMaintenance.FaultVerification.Repos;
using RoadMaintenance.FaultVerification.Core.Model;
using RoadMaintenance.FaultVerification.Services.Response;
using RoadMaintenance.FaultVerification.Repos.Interfaces;


namespace RoadMaintenance.FaultVerification.Services
{
    public class FaultService : IFaultService
    {
        private IFaultRepository _repository;
        
        public FaultService(IFaultRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<FaultView> GetJurisdictionFaults(GetJuristdictionFaultsRequest request)
        {
            //return new List<Response.FaultView>();
            //return new List<Fault>();

            var responseFaults = _repository.SearchForFaultsInJurisdiction();
            var response = new List<FaultView>();

            foreach (var item in responseFaults)
            {
                var faultView = new FaultView(item.Id, item.Address.Street, item.Address.CrossStreet, item.Address.Suburb, item.Address.PostCode, item.GpsCoordinates.Longitude, item.GpsCoordinates.Latitude, item.Status, item.Type, 1,2);
                response.Add(faultView);
            }

            return response.Where(f => f.Id.ToString().ToUpper() == "202947AF-130F-4494-8C50-DB84A93648E1" || 
                f.Id.ToString().ToUpper() == "282A10B0-103E-40F9-8D01-320D002EFF9F");

        }
    }
}
