using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.ApplicationLayer;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using Status = RoadMaintenance.FaultLogging.Core.Enums.Status;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Fault : Entity<Guid>, IEquatable<Fault>
    {
        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public Address Address { get; private set; }
        public DateTime? DateCompleted { get; set; }
        
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
            IEnumerable<Call> calls)
        {
            Guard.ForNull(address, "address");
            
            var newRec = new Fault(id);

            newRec.UpdateType(type);
            newRec.UpdateStatus(status);
            newRec.UpdateAddress(address);
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

        public bool Equals(Fault other)
        {
            foreach (var call in Calls)
            {
                if (!other.Calls.Any(c => c.ReferenceNumber.Equals(call.ReferenceNumber)))
                    return false;
            }
            
            return Id.Equals(other.Id) &&
                   Type.Equals(other.Type) &&
                   Status.Equals(other.Status) &&
                   Address.Equals(other.Address) &&
                   DateCompleted.Equals(other.DateCompleted);
        }
    }
}
