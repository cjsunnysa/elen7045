using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public Location Location { get; private set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? EstimatedCompletionDate { get; private set; }
        
        private readonly List<Call> _calls;
        public IEnumerable<Call> Calls
        {
            get { return _calls; }
        }

        private Fault(Guid id, Type type, Status status)
            : base(id)
        {
            Type = type;
            Status = status;
            _calls = new List<Call>();
        }
        
        private Fault(Type type, Status status) : base(Guid.NewGuid())
        {
            Type = type;
            Status = status;
            _calls = new List<Call>();
        }


        public static Fault Create(Type type, Status status)
        {
            return new Fault(type, status);
        }

        private static Fault Create(Guid faultId, Type type, Status status)
        {
            return new Fault(faultId, type, status);
        }

        public static Fault Create(Guid faultId, Type type, Status status, DateTime? dateCompleted, DateTime? estimatedCompletionDate)
        {
            var newFault = Create(faultId, type, status);

            newFault.UpdateDateCompleted(dateCompleted);
            newFault.UpdateEstimatedCompletionDate(estimatedCompletionDate);

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
            Location = Location.Create(Location == null ? null : Location.GpsCoordinates, address);
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
            Location = Location.Create(gps, Location.Address);
        }
    }
}
