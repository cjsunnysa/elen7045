using System;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Call : Entity<string>
    {
        public string ReferenceNumber { get; private set; }
        public int OperatorId { get; private set; }
        public DateTime TransactionDate { get; private set; }

        private Call(string referenceNum, int operatorId, DateTime callDate) : base(referenceNum)
        {
            OperatorId = operatorId;
            TransactionDate = callDate;
        }

        public Call Create(string referenceNumber, int operatorId, DateTime callDate)
        {
            return new Call(referenceNumber, operatorId, callDate);
        }

        public static Call Create(int operatorId, DateTime callDate)
        {
            var referenceNumber = GenerateNewReferenceNumber();

            return new Call(referenceNumber, operatorId, callDate);
        }

        private static string GenerateNewReferenceNumber()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}