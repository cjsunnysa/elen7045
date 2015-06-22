using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Services.Response;
using RoadMaintenance.FaultLogging.Specs.Model;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public static class ExtensionMethods
    {
        public static FaultSearchResponse ToResponse(this FaultTest testData)
        {
            return new FaultSearchResponse(testData.Id,(Type)testData.TypeId, (Status)testData.StatusId,
                new Address(testData.Street, testData.CrossStreet, testData.Suburb, testData.PostCode),
                testData.EstimatedCompletionDate,testData.DateCompleted);
        }

        public static Fault ToDomainModel(this FaultTest testData)
        {
            return Fault.Create(testData.Id, (Type) testData.TypeId, (Status) testData.StatusId,
                new Address(testData.Street, testData.CrossStreet, testData.Suburb, testData.PostCode),
                testData.DateCompleted, testData.EstimatedCompletionDate, null);
        }
    }
}