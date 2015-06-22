using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.ApplicationLayer;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services.DTO;
using RoadMaintenance.FaultLogging.Services.Response;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services
{
    public class FaultService
    {
        private readonly IRepository<Fault,Guid> _repository;

        public FaultService(IRepository<Fault, Guid> repository)
        {
            _repository = repository;
        }

        public Type GetType(string description)
        {
            switch (description)
            {
                case "Pothole": return Type.Pothole;
                case "Faulty Traffic Light": return Type.FaultyTrafficLight;
                case "Road Marking": return Type.RoadMarking;
                default: throw new ArgumentOutOfRangeException("description", string.Format("{0} is not a fault type.", description));
            }
        }

        public FaultSearchResponse Find(Guid id)
        {
            var fault = _repository.Find(id);
            return fault == null
                   ? null
                   : new FaultSearchResponse(fault.Id, fault.Type, fault.Status, fault.Address,fault.EstimatedCompletionDate, fault.DateCompleted);
        }

        public IEnumerable<FaultSearchResponse> Search(FaultSearchRequest request)
        {
            Guard.ForAllPropertiesNullOrEmpty(request, "searchRequest");

            var street1 = string.IsNullOrEmpty(request.Street1)
                          ? null
                          : request.Street1.ToLower();

            var street2 = string.IsNullOrEmpty(request.Street2)
                          ? null
                          : request.Street2.ToLower();

            var suburb = string.IsNullOrEmpty(request.Suburb)
                          ? null
                          : request.Suburb.ToLower();

            return from d in _repository.Search()
                   let s = d.Address.Street.ToLower()
                   let cs = d.Address.CrossStreet.ToLower()
                   let sub = d.Address.Suburb.ToLower()
                   where
                       (street1 == null || s.Contains(street1) || cs.Contains(street1)) &&
                       (street2 == null || s.Contains(street2) || cs.Contains(street2)) &&
                       (suburb == null || sub.Contains(suburb)) &&
                       (request.Type == null || d.Type == request.Type) &&
                       (d.Status != Status.Repaired ||
                            (request.RepairedPeriodStartDate != null && d.DateCompleted != null && d.DateCompleted >= (DateTime)request.RepairedPeriodStartDate))
                   select new FaultSearchResponse(d.Id,d.Type,d.Status,d.Address,d.EstimatedCompletionDate,d.DateCompleted);
        }
    }
}
