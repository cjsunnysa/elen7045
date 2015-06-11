using System;

namespace RoadMaintenance.DataService.DTO
{
    [Serializable]
    public class FaultDTO
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}