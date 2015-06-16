using System;
using FaultLogging.Core.Interfaces;

namespace FaultLogging.Core.Model
{
    public class Transaciton : Entity<Guid>
    {
        public int OperatorId { get; private set; }
        public int TransactionTypeId { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public Transaciton(Guid id, int operatorId, int typeId, DateTime transactionDate) : base(id)
        {
            OperatorId = operatorId;
            TransactionTypeId = typeId;
            TransactionDate = transactionDate;
        }
    }
}