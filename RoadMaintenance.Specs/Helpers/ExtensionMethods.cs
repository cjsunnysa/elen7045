using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services.Response;
using RoadMaintenance.FaultLogging.Specs.Model;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public static class ExtensionMethods
    {
        public static FaultDetailsView ToResponse(this FaultTest testData)
        {
            var address = Address.Create(testData.Street, testData.CrossStreet, testData.Suburb, testData.PostCode);
            var gps = (testData.Longitude == null || testData.Latitude == null)
                      ? null
                      : GPSCoordinates.Create(testData.Longitude, testData.Latitude);

            return new FaultDetailsView(
                testData.Id,
                (Type)testData.TypeId, 
                (Status)testData.StatusId,
                testData.EstimatedCompletionDate,
                testData.DateCompleted,
                address,
                gps);
        }

        public static Fault ToDomainModel(this FaultTest testData)
        {
            var address = Address.Create(testData.Street, testData.CrossStreet, testData.Suburb, testData.PostCode);
            var gps = (string.IsNullOrEmpty(testData.Longitude) || string.IsNullOrEmpty(testData.Latitude)) 
                      ? null
                      : GPSCoordinates.Create(testData.Longitude, testData.Latitude);

            var fault = Fault.Create(
                testData.Id, 
                (Type) testData.TypeId, 
                (Status) testData.StatusId,
                testData.DateCompleted, 
                testData.EstimatedCompletionDate,
                address,
                gps);

            return fault;
        }
    }
}