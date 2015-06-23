using System;
using System.Collections.Generic;
using RoadMaintenance.ApplicationLayer;
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
        public DateTime? DateCompleted { get; set; }
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

        private Fault(Guid id, Type type, Status status, DateTime? dateCompleted, DateTime? estimatedCompletionDate, Address address, GPSCoordinates gps) : base(id)
        {
            Status = status;
            Type = type;
            DateCompleted = dateCompleted;
            EstimatedCompletionDate = estimatedCompletionDate;
            Address = address;
            GpsCoordinates = gps;
        }


        public static Fault Create(Type type, Status status)
        {
            return new Fault(type, status);
        }

        public static Fault Create(Guid faultId, Type type, Status status, DateTime? dateCompleted, DateTime? estimatedCompletionDate, Address address, GPSCoordinates gps)
        {
            var newFault = new Fault(faultId, type, status, dateCompleted, estimatedCompletionDate, address, gps);
            
            return newFault;
        }
        
        
        public void AddCall(Call call)
        {
            _calls.Add(call);
        }

        public void UpdateStatus(Status status)
        {
            Status = status;
        }

        public void UpdateAddress(Address address)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the address of a fault when the status is \"Pending Investigation\"");

            Address = address;
        }

        public void UpdateDateCompleted(DateTime? dateCompleted)
        {
            DateCompleted = dateCompleted;
        }
        
        public void UpdateEstimatedCompletionDate(DateTime? estCompletionDate)
        {
            EstimatedCompletionDate = estCompletionDate;
        }

        public void UpdateGPSCoordinates(GPSCoordinates gps)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the GPS coordinates of a fault when the status is \"Pending Investigation\"");

            GpsCoordinates = gps;
        }
    }
}
