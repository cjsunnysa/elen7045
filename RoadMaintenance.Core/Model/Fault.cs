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
        public DateTime? DateCompleted { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        
        
        private readonly List<Call> _calls;
        public IEnumerable<Call> Calls
        {
            get { return _calls; }
        }
        
        
        private Fault(Guid id) : base(id)
        {
            _calls = new List<Call>();
        }

        public static Fault Create(Type type, Status status, Address address)
        {
            var newRec = new Fault(Guid.NewGuid());

            newRec.UpdateType(type);
            newRec.UpdateStatus(status);
            newRec.UpdateAddress(address);

            return newRec;
        }

        public static Fault Create(
            Guid id, 
            Type type, 
            Status status, 
            Address address,
            DateTime? dateCompleted,
            DateTime? estCompletionDate,
            IEnumerable<Call> calls)
        {
            Guard.ForNull(address, "address");
            
            var newRec = new Fault(id);

            newRec.UpdateType(type);
            newRec.UpdateStatus(status);
            newRec.UpdateAddress(address);
            newRec.UpdateEstimatedCompletionDate(estCompletionDate);
            newRec.UpdateDateCompleted(dateCompleted);

            if (calls != null)
                newRec.AddCalls(calls);

            return newRec;
        }

        public void UpdateType(Type type)
        {
            Type = type;
        }

        public void UpdateStatus(Status status)
        {
            Status = status;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void UpdateEstimatedCompletionDate(DateTime? estCompletionDate)
        {
            EstimatedCompletionDate = estCompletionDate;
        }

        public void UpdateDateCompleted(DateTime? dateCompleted)
        {
            DateCompleted = dateCompleted;
        }

        public void AddCalls(Call call)
        {
            _calls.Add(call);
        }

        public void AddCalls(IEnumerable<Call> calls)
        {
            _calls.AddRange(calls);
        }
    }
}
