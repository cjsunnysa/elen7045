using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Enums;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public static class ExtensionMethods
    {
        public static Fault ToDomainModel(this FaultTest testData)
        {
            return Fault.Create(
                testData.Id, 
                (Type) testData.TypeId, 
                (Status) testData.StatusId, 
                new Address(testData.Street,testData.CrossStreet,testData.Suburb,testData.PostCode),
                null);
        }
    }
}