using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Specs.Model;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public static class ExtensionMethods
    {
        public static Fault ToDomainModel(this FaultTest testData)
        {
            return Fault.Create(
                id:                 testData.Id, 
                type:          (Type) testData.TypeId, 
                status:             (Status) testData.StatusId, 
                address:            new Address(
                    street:             testData.Street, 
                    crossStreet:        testData.CrossStreet, 
                    suburb:             testData.Suburb, 
                    postCode:           testData.PostCode), 
                dateCompleted:      testData.DateCompleted, 
                calls:              null);
        }
    }
}