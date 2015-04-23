using System;

namespace RoadMaintenance.DataService.DTO
{
    public class FaultDTO
    {
        public int Id { get; set; }
        public AddressDTO Address { get; set; }
        public int FaultTypeId { get; set; }
        public int StatusId { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
    }
}