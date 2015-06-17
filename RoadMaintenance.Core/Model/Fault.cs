using System;
using System.Collections.Generic;
using RoadMaintenance.ApplicationLayer;
using RoadMaintenance.SharedKernel.Core.Enums;
using RoadMaintenance.SharedKernel.Repos.Interfaces;
using Type = RoadMaintenance.SharedKernel.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Fault : Entity<Guid>, IEquatable<Fault>
    {
        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public Address Address { get; private set; }
        
        private readonly List<Call> _transactions;
        public IEnumerable<Call> Transacitons
        {
            get { return _transactions; }
        }

        private Fault(Guid id) : base(id)
        {
            _transactions = new List<Call>();
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
            IEnumerable<Call> transactions)
        {
            Guard.ForNull(address, "address");
            
            var newRec = new Fault(id);

            newRec.UpdateType(type);
            newRec.UpdateStatus(status);
            newRec.UpdateAddress(address);
            if (transactions != null)
                newRec.AddTransactions(transactions);

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

        public void AddTransaction(Call transaction)
        {
            _transactions.Add(transaction);
        }

        public void AddTransactions(IEnumerable<Call> transacitons)
        {
            _transactions.AddRange(transacitons);
        }

        public bool Equals(Fault other)
        {
            return Id.Equals(other.Id) &&
                   Type.Equals(other.Type) &&
                   Status.Equals(other.Status) &&
                   Address.Equals(other.Address);
        }
    }
}
