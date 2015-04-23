using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoadMaintenance.DataService;
using RoadMaintenance.DataService.Datastore;
using RoadMaintenance.DataService.DTO;

namespace RoadMaintenance.MVC.Models.Converters
{
    public static class DataRepositoryToModelExtensions
    {
        public static FaultModel ToModel(this FaultDTO fault)
        {
            return new FaultModel
            {
                Id = fault.Id,
                Status = LookupTables.FaultStatuses[fault.StatusId],
                Type = LookupTables.FaultTypes[fault.FaultTypeId],
                Address1 = fault.Address.Address1,
                Address2 = fault.Address.Address2,
                Suburb = fault.Address.Suburb,
                PostCode = fault.Address.PostCode,
                EstimatedCompletionDate = fault.EstimatedCompletionDate,
            };
        }
    }
}