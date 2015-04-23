using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.DataService.DTO;

namespace RoadMaintenance.DataService.Datastore
{
    public static class RoadMaintenanceDatabase
    {
        public static FaultDTO[] GetAllFaults()
        {
            return new[]
            {
                new FaultDTO
                {
                    Id = 1,
                    Address = new AddressDTO
                    {
                        GeoCode  = "",
                        Address1 = "1 Sandton Dr",
                        Address2 = "",
                        Suburb   = "Sandton",
                        PostCode = "2196",
                    },
                    StatusId = 1,
                    FaultTypeId = 1,
                    EstimatedCompletionDate = null,
                },
                new FaultDTO
                {
                    Id = 2,
                    Address = new AddressDTO
                    {
                        GeoCode  = "",
                        Address1 = "cnr Ballyclare",
                        Address2 = "Sycamore",
                        Suburb   = "Sandton",
                        PostCode = "2191",
                    },
                    StatusId = 1,
                    FaultTypeId = 2,
                    EstimatedCompletionDate = null,
                },
                new FaultDTO
                {
                    Id = 3,
                    Address = new AddressDTO
                    {
                        GeoCode  = "",
                        Address1 = "cnr Beyers Naude",
                        Address2 = "Christiaan De Wet",
                        Suburb   = "Randburg",
                        PostCode = "2196",
                    },
                    StatusId = 1,
                    FaultTypeId = 3,
                    EstimatedCompletionDate = null,
                },
                new FaultDTO
                {
                    Id = 4,
                    Address = new AddressDTO
                    {
                        GeoCode  = "",
                        Address1 = "cnr Sandton drive",
                        Address2 = "Elizabeth ave",
                        Suburb   = "Sandton",
                        PostCode = "2196",
                    },
                    StatusId = 1,
                    FaultTypeId = 4,
                    EstimatedCompletionDate = null,
                },
                new FaultDTO
                {
                    Id = 5,
                    Address = new AddressDTO
                    {
                        GeoCode  = "",
                        Address1 = "cnr Boundry Ln",
                        Address2 = "Victoria Ave",
                        Suburb   = "Sandton",
                        PostCode = "2196",
                    },
                    StatusId = 1,
                    FaultTypeId = 5,
                    EstimatedCompletionDate = null,
                },
                new FaultDTO
                {
                    Id = 6,
                    Address = new AddressDTO
                    {
                        GeoCode  = "",
                        Address1 = "Boundry Rd",
                        Address2 = "",
                        Suburb   = "Sandton",
                        PostCode = "2196",
                    },
                    StatusId = 1,
                    FaultTypeId = 1,
                    EstimatedCompletionDate = null,
                },
            };
        }
    }
}
