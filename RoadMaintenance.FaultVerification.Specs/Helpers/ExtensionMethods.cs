using RoadMaintenance.FaultVerification.Core.DTO;
using RoadMaintenance.FaultVerification.Core.Enums;
using RoadMaintenance.FaultVerification.Core.Model;
using RoadMaintenance.FaultVerification.Specs.Model;
using System;

using Type = RoadMaintenance.FaultVerification.Core.Enums.Type;

namespace RoadMaintenance.FaultVerification.Specs.Helpers
{
    public static class ExtensionMethods
    {
        //public static FaultDetailsView ToResponse(this FaultTestData testData)
        //{
        //    return new FaultDetailsView(
        //        testData.Id,
        //        (Type)testData.TypeId,
        //        (Status)testData.StatusId,
        //        testData.EstimatedCompletionDate,
        //        testData.DateCompleted,
        //        testData.Street,
        //        testData.CrossStreet,
        //        testData.Suburb,
        //        testData.PostCode,
        //        testData.Latitude,
        //        testData.Longitude);
        //}

        public static Fault ToDomainModel(this FaultTestData testData)
        {
            var fault = Fault.Create(
                testData.Id,
                (Type)testData.Type,
                (Status)testData.Status,
               
                new AddressDTO
                {
                    StreetName = testData.Street,
                    CrossStreet = testData.CrossStreet,
                    Suburb = testData.Suburb,
                    PostCode = testData.PostCode,
                },
                string.IsNullOrEmpty(testData.Latitude)
                ? null
                : new GpsDTO { Latitude = testData.Latitude, Longitude = testData.Longitude });

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