using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Enums;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public static class ExtensionMethods
    {
        public static Fault ToDomainModel(this FaultTest testData)
        {
            return Fault.Create(
                id:           testData.Id, 
                type:         (Type) testData.TypeId, 
                status:       (Status) testData.StatusId, 
                address:      new Address(
                                  street: testData.Street, 
                                  crossStreet: testData.CrossStreet, 
                                  suburb: testData.Suburb, 
                                  postCode: testData.PostCode), 
                transactions: null);
        }
    }
}