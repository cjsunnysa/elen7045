using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using RoadMaintenance.Common;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Fault : Entity<Guid>
    {
        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public Address Address { get; private set; }
        public GPSCoordinates GpsCoordinates { get; private set; }
        public DateTime? DateCompleted { get; private set; }
        public DateTime? EstimatedCompletionDate { get; private set; }
        
        private readonly List<Call> _calls;
        public IEnumerable<Call> Calls
        {
            get { return _calls; }
        }

        private Fault(Type type, Status status) : base(Guid.NewGuid())
        {
            Guard.ForNull(type, "type");
            Guard.ForNull(status, "status");

            Type = type;
            Status = status;
            _calls = new List<Call>();
        }

        private Fault(Guid id, Type type, Status status, DateTime? dateCompleted, DateTime? estimatedCompletionDate, AddressDTO address, GpsDTO gps) : base(id)
        {
            Status = status;
            Type = type;
            DateCompleted = dateCompleted;
            EstimatedCompletionDate = estimatedCompletionDate;

            if (address != null)
                Address = Address.Create(address.StreetName, address.CrossStreet, address.Suburb, address.PostCode);

            if (gps != null)
                GpsCoordinates = GPSCoordinates.Create(gps.Latitude, gps.Longitude);

            _calls = new List<Call>();
        }

        public static Fault Create(Type type, Status status)
        {
            return new Fault(type, status);
        }

        public static Fault Create(Guid id, Type type, Status status, DateTime? dateCompleted,
            DateTime? estimatedDateTime, AddressDTO address, GpsDTO gps)
        {
            return new Fault(id,type,status,dateCompleted,estimatedDateTime,address,gps);
        }


        public void UpdateAddress(AddressDTO address)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the address of a fault when the status is \"Pending Investigation\"");

            Address = Address.Create(address.StreetName, address.CrossStreet, address.Suburb, address.PostCode);
        }

        public void UpdateGPSCoordinates(GpsDTO gps)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the GPS coordinates of a fault when the status is \"Pending Investigation\"");

            GpsCoordinates = GPSCoordinates.Create(gps.Latitude, gps.Longitude);
        }
        
        public string CreateCall(int operatorId, DateTime callDate)
        {
            var call = Call.Create(operatorId, callDate);
            
            _calls.Add(call);

            return call.ReferenceNumber;
        }

        public void AddCall(CallDTO call)
        {
            _calls.Add(Call.Create(call.ReferenceNumber, call.OperatorId, call.CallDate));
        }
        

        public void UpdateStatus(Status status)
        {
            Status = status;
        }

        public void UpdateDateCompleted(DateTime? dateCompleted)
        {
            DateCompleted = dateCompleted;
        }
        
        public void UpdateEstimatedCompletionDate(DateTime? estCompletionDate)
        {
            EstimatedCompletionDate = estCompletionDate;
        }

    }
}
