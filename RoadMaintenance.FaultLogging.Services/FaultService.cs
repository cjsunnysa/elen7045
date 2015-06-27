using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using RoadMaintenance.Common;
using RoadMaintenance.FaultLogging.Core.DTO;
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
                   : new FaultDetailsView(
                       fault.Id, 
                       fault.Type, 
                       fault.Status, 
                       fault.EstimatedCompletionDate, 
                       fault.DateCompleted, 
                       fault.Address.Street,
                       fault.Address.CrossStreet,
                       fault.Address.Suburb,
                       fault.Address.PostCode,
                       fault.GpsCoordinates == null ? null : fault.GpsCoordinates.Latitude,
                       fault.GpsCoordinates == null ? null : fault.GpsCoordinates.Longitude);
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
                   select new FaultDetailsView(
                       d.Id,
                       d.Type,
                       d.Status,
                       d.EstimatedCompletionDate,
                       d.DateCompleted,
                       d.Address.Street,
                       d.Address.CrossStreet,
                       d.Address.Suburb,
                       d.Address.PostCode,
                       d.GpsCoordinates == null ? null : d.GpsCoordinates.Latitude,
                       d.GpsCoordinates == null ? null : d.GpsCoordinates.Longitude);
        }

        [MethodSecurity]
        public Guid CreateFault(CreateFaultRequest request)
        {
            var fault = Fault.Create(request.Type, Status.PendingInvestigation);

            var address = new AddressDTO
            {
                StreetName = request.StreetName,
                CrossStreet = request.CrossStreet,
                Suburb = request.Suburb,
                PostCode = request.PostCode
            };

            fault.UpdateAddress(address);

            _repository.Save(fault);

            
            return fault.Id;
        }

        [MethodSecurity]
        public void UpdateGpsCoordinates(UpdateGpsCoordinatesRequest request)
        {
            Guard.ForNull(request.FaultId, "request.FaultId");

            var fault = _repository.Find(request.FaultId);
            if (fault == null)
                throw new ArgumentException(string.Format("Fault Id {0} does not exist", request.FaultId), "request");

            var gps = new GpsDTO
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude
            };

            fault.UpdateGPSCoordinates(gps);

            _repository.Save(fault);
        }

        [MethodSecurity]
        public void UpdateAddress(UpdateAddressRequest request)
        {
            Guard.ForNull(request.FaultId, "request.FaultId");

            var fault = _repository.Find(request.FaultId);
            if (fault == null)
                throw new ArgumentException(string.Format("Fault Id {0} does not exist", request.FaultId), "request");

            var address = new AddressDTO
            {
                StreetName = request.StreetName,
                CrossStreet = request.CrossStreet,
                Suburb = request.Suburb,
                PostCode = request.PostCode

            };
            
            fault.UpdateAddress(address);

            _repository.Save(fault);
        }

        [MethodSecurity]
        public string GetNewCallReference(CreateCallRequest request)
        {
            var fault = _repository.Find(request.FaultId);
            if (fault == null)
                throw new ArgumentException(string.Format("Fault Id {0} does not exist", request.FaultId), "request.FaultId");

            var callReference = fault.CreateCall(request.OperatorId, request.CallDateTime);

            return callReference;
        }
    }
}
