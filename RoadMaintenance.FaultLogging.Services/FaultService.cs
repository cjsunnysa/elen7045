using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RoadMaintenance.ApplicationLayer;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services.Interfaces;
using RoadMaintenance.FaultLogging.Services.Request;
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

        public FaultSearchResponse Find(Guid id)
        {
            var fault = _repository.Find(id);
            return fault == null
                   ? null
                   : new FaultSearchResponse(fault.Id, fault.Type, fault.Status, fault.Location,fault.EstimatedCompletionDate, fault.DateCompleted);
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
                   let s = d.Location.Address.Street.ToLower()
                   let cs = d.Location.Address.CrossStreet.ToLower()
                   let sub = d.Location.Address.Suburb.ToLower()
                   where
                       (street1 == null || s.Contains(street1) || cs.Contains(street1)) &&
                       (street2 == null || s.Contains(street2) || cs.Contains(street2)) &&
                       (suburb == null || sub.Contains(suburb)) &&
                       (request.Type == null || d.Type == request.Type) &&
                       (d.Status != Status.Repaired ||
                            (request.RepairedPeriodStartDate != null && d.DateCompleted != null && d.DateCompleted >= (DateTime)request.RepairedPeriodStartDate))
                   select new FaultSearchResponse(d.Id,d.Type,d.Status,d.Location,d.EstimatedCompletionDate,d.DateCompleted);
        }

        public CreateFaultResponse CreateFault(CreateFaultRequest request)
        {
            Guard.ForNull(request.Type, "request.Type");

            var faultRec = _repository.Search().SingleOrDefault(f => 
                f.Location.Address.Street.Equals(request.StreetName, StringComparison.CurrentCultureIgnoreCase) &&
                f.Location.Address.CrossStreet.Equals(request.CrossStreet, StringComparison.CurrentCultureIgnoreCase) &&
                f.Location.Address.Suburb.Equals(request.Suburb, StringComparison.CurrentCultureIgnoreCase));

            if (faultRec == null)
            {
                faultRec = Fault.Create(request.Type, Status.PendingInvestigation);
                var address = Address.Create(request.StreetName, request.CrossStreet, request.Suburb, request.PostCode);

                faultRec.UpdateAddress(address);
            }


            var call = Call.Create(request.OperatorId, request.CurrentDateTime);
            
            faultRec.AddCall(call);
            
            _repository.Save(faultRec);

            
            return new CreateFaultResponse(
                faultRec.Id, 
                faultRec.Location.Address.Street,
                faultRec.Location.Address.CrossStreet, 
                faultRec.Location.Address.Suburb, 
                faultRec.Location.Address.PostCode,
                faultRec.Status, 
                faultRec.Type, 
                call.ReferenceNumber);
        }
    }
}
