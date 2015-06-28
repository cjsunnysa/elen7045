using System;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services.Response;
using RoadMaintenance.FaultLogging.Specs.Model;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public static class ExtensionMethods
    {
        public static FaultDetailsView ToResponse(this FaultTest testData)
        {
            return new FaultDetailsView(
                testData.Id,
                (Type)testData.TypeId, 
                (Status)testData.StatusId,
                testData.Description,
                testData.EstimatedCompletionDate,
                testData.DateCompleted,
                testData.Street,
                testData.CrossStreet,
                testData.Suburb,
                testData.PostCode,
                testData.Latitude,
                testData.Longitude);
        }

        public static Fault ToDomainModel(this FaultTest testData)
        {
            var fault = Fault.Create(
                testData.Id,
                (Type) testData.TypeId,
                (Status) testData.StatusId,
                testData.Description,
                testData.DateCompleted,
                testData.EstimatedCompletionDate,
                new AddressDTO
                {
                    StreetName = testData.Street,
                    CrossStreet = testData.CrossStreet,
                    Suburb = testData.Suburb,
                    PostCode = testData.PostCode,
                },
                string.IsNullOrEmpty(testData.Latitude)
                ? null
                : new GpsDTO {Latitude = testData.Latitude, Longitude = testData.Longitude});

            return fault;
        }

        public static DateTime AsDateTime(this string dateString)
        {
            var year = Int32.Parse(dateString.Substring(0, 4));
            var month = Int32.Parse(dateString.Substring(5, 2));
            var day = Int32.Parse(dateString.Substring(8, 2));

            return new DateTime(year, month, day);
        }
    }
}