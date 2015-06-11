using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.DataService.DTO;
using RoadMaintenance.DataService.Interfaces;

namespace RoadMaintenance.DataService.Datastore
{
    public class RoadMaintenanceDatabase : IRoadMaintenanceDatasource
    {
        private readonly FaultDTO[] _faults;

        public RoadMaintenanceDatabase()
        {
            _faults = CreateData();
        }

        public IEnumerable<FaultDTO> GetFaults()
        {
            return _faults;
        }

        public IEnumerable<FaultTypeDTO> GetFaultTypes()
        {
            return LookupTables.FaultTypes.Select(t => new FaultTypeDTO {Id = t.Key, Description = t.Value});
        }

        public IEnumerable<FaultStatusDTO> GetFaultStatuses()
        {
            return LookupTables.FaultStatuses.Select(s => new FaultStatusDTO {Id = s.Key, Description = s.Value});
        }

        private FaultDTO[] CreateData()
        {
            return new[]
            {
                new FaultDTO
                {
                    Id = 1,
                    Latitude = null,
                    Longitude = null,
                    Street = "8th Street",
                    Suburb = "Sandton",
                    PostCode = "2196",
                    StatusId = 1,
                    Status = LookupTables.FaultStatuses[1],
                    TypeId = 1,
                    Type = LookupTables.FaultTypes[1],
                    EstimatedCompletionDate = null,
                    DateCompleted = null,
                },
                new FaultDTO
                {
                    Id = 4,
                    Latitude = "-26.160226",
                    Longitude = "27.975857",
                    Street = "8th Street",
                    Suburb = "Randburg",
                    PostCode = "2195",
                    StatusId = 1,
                    Status = LookupTables.FaultStatuses[5],
                    TypeId = 1,
                    Type = LookupTables.FaultTypes[3],
                    EstimatedCompletionDate = null,
                    DateCompleted = null,
                },
                new FaultDTO
                {
                    Id = 5,
                    Latitude = null,
                    Longitude = null,
                    Street = "12th Street",
                    Suburb = "Linden",
                    PostCode = "2105",
                    StatusId = 1,
                    Status = LookupTables.FaultStatuses[5],
                    TypeId = 1,
                    Type = LookupTables.FaultTypes[3],
                    EstimatedCompletionDate = null,
                    DateCompleted = null,
                },
                new FaultDTO
                {
                    Id = 10,
                    Latitude = null,
                    Longitude = null,
                    Street = "Hill St",
                    Suburb = "Randburg",
                    PostCode = "2194",
                    StatusId = 1,
                    Status = LookupTables.FaultStatuses[5],
                    TypeId = 1,
                    Type = LookupTables.FaultTypes[3],
                    EstimatedCompletionDate = null,
                    DateCompleted = null,
                },
                new FaultDTO
                {
                    Id = 15,
                    Latitude = null,
                    Longitude = null,
                    Street = "Barry Hertzog",
                    Suburb = "Greenside",
                    PostCode = "2195",
                    StatusId = 1,
                    Status = LookupTables.FaultStatuses[5],
                    TypeId = 1,
                    Type = LookupTables.FaultTypes[3],
                    EstimatedCompletionDate = null,
                    DateCompleted = null,
                },
            };
        }

    }
}
