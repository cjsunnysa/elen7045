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
        public Address Address { get; private set; }
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

        public static Fault Create(Guid faultId, Type type, Status status, string street, string crossStreet, string suburb, string postCode, DateTime? dateCompleted, DateTime? estimatedCompletionDate)
        {
            var newFault = Create(faultId, type, status);

            newFault.UpdateDateCompleted(dateCompleted);
            newFault.UpdateEstimatedCompletionDate(estimatedCompletionDate);

            newFault.CreateAddress(street, crossStreet, suburb, postCode);

            return newFault;
        }

        public static Fault Create(Type type, string streetName, string crossStreet, string suburb)
        {
            var fault = new Fault(type, Enums.Status.PendingInvestigation);

            fault.CreateAddress(streetName, crossStreet, suburb, "");

            return fault;
        }
        
        public Address CreateAddress(string street, string crossStreet, string suburb, string postCode)
        {
            Guard.ForNullOrEmpty(street, "street");

            var address = Address.Create(street, crossStreet, suburb, postCode);
            
            UpdateAddress(address);

            return Address;
        }

        public Call CreateCall(int operatorId, DateTime callDate)
        {
            Guard.ForLessEqualToZero(operatorId, "operatorId");

            var call = Call.Create(operatorId, callDate);

            _calls.Add(call);

            return call;
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

        
    }
}
