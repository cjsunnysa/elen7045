using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using RoadMaintenance.Common;
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

        private Fault(Guid id, Type type, Status status, DateTime? dateCompleted, DateTime? estimatedCompletionDate) : base(id)
        {
            Status = status;
            Type = type;
            DateCompleted = dateCompleted;
            EstimatedCompletionDate = estimatedCompletionDate;

            _calls = new List<Call>();
        }


        public static Fault Create(Type type, Status status)
        {
            return new Fault(type, status);
        }

        public static Fault Create(Guid faultId, Type type, Status status, DateTime? dateCompleted,
            DateTime? estimatedCompletionDate, string street, string crossStreet, string suburb, string postCode,
            string latitude, string longitude)
        {
            var fault = new Fault(faultId, type, status, dateCompleted, estimatedCompletionDate)
            {
                Address = Model.Address.Create(street, crossStreet, suburb, postCode),
                GpsCoordinates = string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude)
                                 ? null 
                                 : GPSCoordinates.Create(longitude, latitude)
            };

            return fault;
        }

        public void CreateAddress(string streetName, string crossStreet, string suburb, string postCode)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the address of a fault when the status is \"Pending Investigation\"");

            Address = Address.Create(streetName, crossStreet, suburb, postCode);
        }

        public void CreateGPSCoordinates(string longitude, string latitude)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the GPS coordinates of a fault when the status is \"Pending Investigation\"");

            GpsCoordinates = GPSCoordinates.Create(longitude, latitude);
        }
        
        public string CreateCall(int operatorId, DateTime callDate)
        {
            var call = Call.Create(operatorId, callDate);
            
            _calls.Add(call);

            return call.ReferenceNumber;
        }

        public void AddCall(string referenceNumber, int operatorId, DateTime callDate)
        {
            _calls.Add(Call.Create(referenceNumber, operatorId, callDate));
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
