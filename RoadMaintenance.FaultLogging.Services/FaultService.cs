using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.ApplicationLayer;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.FaultLogging.Services.Interfaces;
using RoadMaintenance.FaultLogging.Services.Request;
using RoadMaintenance.FaultLogging.Services.Response;
using RoadMaintenance.SharedKernel.Services;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Services
{
    public class FaultService : IFaultService
    {
        private readonly IFaultRepository _repository;
        
        public FaultService(IFaultRepository repository)
        {
            _repository = repository;
        }

        [MethodSecurity]
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

        [MethodSecurity]
        public string GetStatusDescription(Status status)
        {
            switch (status)
            {
                case Status.PendingInvestigation:
                    return "Pending Investigation";
                case Status.PendingTeamDispatch:
                    return "Pending Team Dispatch";
                case Status.InProgress:
                    return "In Progress";
                case Status.OnHold:
                    return "On Hold";
                case Status.Rejected:
                    return "Rejected";
                case Status.Repaired:
                    return "Repaired";
                default:
                    throw new ArgumentOutOfRangeException("status", string.Format("{0} does not exist.",status));
            }
        }

        [MethodSecurity]
        public FaultDetailsView Find(Guid id)
        {
            var fault = _repository.Find(id);
            return fault == null
                   ? null
                   : new FaultDetailsView(fault.Id, fault.Type, fault.Status, fault.EstimatedCompletionDate, fault.DateCompleted, fault.Address, fault.GpsCoordinates);
        }

        [MethodSecurity]
        public IEnumerable<FaultDetailsView> Search(FaultSearchRequest request)
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
                   select new FaultDetailsView(d.Id,d.Type,d.Status,d.EstimatedCompletionDate,d.DateCompleted,d.Address,d.GpsCoordinates);
        }

        [MethodSecurity]
        public Guid CreateFault(CreateFaultRequest request)
        {
            var faultRec = Fault.Create(request.Type, Status.PendingInvestigation);
            
            var address = Address.Create(request.StreetName, request.CrossStreet, request.Suburb, request.PostCode);
            faultRec.UpdateAddress(address);

            _repository.Save(faultRec);

            
            return faultRec.Id;
        }

        [MethodSecurity]
        public void UpdateGpsCoordinates(UpdateGpsCoordinatesRequest request)
        {
            Guard.ForNull(request.FaultId, "request.FaultId");

            var faultRec = _repository.Find(request.FaultId);
            if (faultRec == null)
                throw new ArgumentException(string.Format("Fault Id {0} does not exist", request.FaultId), "request");

            var gps = GPSCoordinates.Create(request.Longitude, request.Latitude);

            faultRec.UpdateGPSCoordinates(gps);

            _repository.Save(faultRec);
        }

        [MethodSecurity]
        public void UpdateAddress(UpdateAddressRequest request)
        {
            Guard.ForNull(request.FaultId, "request.FaultId");

            var faultRec = _repository.Find(request.FaultId);
            if (faultRec == null)
                throw new ArgumentException(string.Format("Fault Id {0} does not exist", request.FaultId), "request");

            var address = Address.Create(request.StreetName, request.CrossStreet, request.Suburb, request.PostCode);

            faultRec.UpdateAddress(address);

            _repository.Save(faultRec);
        }
    }
}
