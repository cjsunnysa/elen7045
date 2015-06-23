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
            var address = Address.Create(testData.Street, testData.CrossStreet, testData.Suburb, testData.PostCode);


            return new FaultSearchResponse(
                testData.Id,
                (Type)testData.TypeId, 
                (Status)testData.StatusId,
                Location.Create(address),
                testData.EstimatedCompletionDate,
                testData.DateCompleted);
        }

        public static Fault ToDomainModel(this FaultTest testData)
        {
            var fault = Fault.Create(
                testData.Id, 
                (Type) testData.TypeId, 
                (Status) testData.StatusId,
                testData.DateCompleted, 
                testData.EstimatedCompletionDate);

            var address = Address.Create(testData.Street, testData.CrossStreet, testData.Suburb, testData.PostCode);

            fault.UpdateAddress(address);

            return fault;
        }
    }
}