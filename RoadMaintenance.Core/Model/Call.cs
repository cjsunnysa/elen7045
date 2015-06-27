using System;
using RoadMaintenance.Common;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Core.Model
{
    public class Call : ValueObject<Call>
    {
        public string ReferenceNumber { get; private set; }
        public int OperatorId { get; private set; }
        public DateTime TransactionDate { get; private set; }

        private Call(string referenceNum, int operatorId, DateTime callDate)
        {
            Guard.ForNullOrEmpty(referenceNum, "referenceNum");
            Guard.ForLessEqualToZero(operatorId, "operatorId");

            ReferenceNumber = referenceNum;
            OperatorId = operatorId;
            TransactionDate = callDate;
        }

        private static string GenerateNewReferenceNumber()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
        

        internal static Call Create(string referenceNumber, int operatorId, DateTime callDate)
        {
            return new Call(referenceNumber, operatorId, callDate);
        }

        internal static Call Create(int operatorId, DateTime callDate)
        {
            var referenceNumber = GenerateNewReferenceNumber();

            return new Call(referenceNumber, operatorId, callDate);
        }
    }
}