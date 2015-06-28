using RoadMaintenance.FaultVerification.Core.DTO;
using RoadMaintenance.FaultVerification.Core.Enums;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Type = RoadMaintenance.FaultVerification.Core.Enums.Type;

namespace RoadMaintenance.FaultVerification.Core.Model
{
    public class Fault : Entity<Guid>
    {

        public Type Type { get; private set; }
        public Status Status { get; private set; }
        public Address Address { get; private set; }
        public GPSCoordinates GpsCoordinates { get; private set; }
        public DateTime? DateCompleted { get; private set; }
        public DateTime? EstimatedCompletionDate { get; private set; }

        

        private Fault(Type type, Status status)
            : base(Guid.NewGuid())
        {
            //Guard.ForNull(type, "type");
            //Guard.ForNull(status, "status");

            Type = type;
            Status = status;
            //_calls = new List<Call>();
        }

     
         private Fault(Guid id, string street, string crossStreet, string suburb, string postCode, string longitude, string latitude, string statusId, string typeId)
            : base(id)
        {
            Status = (Status)int.Parse(statusId);
            Type = (RoadMaintenance.FaultVerification.Core.Enums.Type)int.Parse(typeId);
           
            if (Address != null)
                Address = Address.Create(street, crossStreet, suburb, postCode);

            //if (GPSCoordinates != null)
                GpsCoordinates = GPSCoordinates.Create(latitude, longitude);

            //_calls = new List<Call>();
        }


         public static Fault Create(Guid id, string street, string crossStreet, string suburb, string postCode, string longitude, string latitude, string statusId, string typeId)
         {
             return new Fault(id, street, crossStreet, suburb, postCode, longitude, latitude, statusId, typeId);
         }

         public static Fault Create(Guid id, Type type, Status status, AddressDTO address, GpsDTO gps)
         {
             return new Fault(id, type, status, address, gps);
         }
        

         private Fault(Guid id, RoadMaintenance.FaultVerification.Core.Enums.Type type, Status status, AddressDTO address, GpsDTO gps)
             : base(id)
         {
             Status = status;
             Type = type;

             if (address != null)
                 Address = Address.Create(address.StreetName, address.CrossStreet, address.Suburb, address.PostCode);

             if (gps != null)
                 GpsCoordinates = GPSCoordinates.Create(gps.Latitude, gps.Longitude);
         }
       


      
        public void UpdateGPSCoordinates(GpsDTO gps)
        {
            if (Status != Status.PendingInvestigation)
                throw new InvalidOperationException("Can only change the GPS coordinates of a fault when the status is \"Pending Investigation\"");

            GpsCoordinates = GPSCoordinates.Create(gps.Latitude, gps.Longitude);
        }

       

        public void UpdateStatus(Status status)
        {
            Status = status;
        }

       

    }
}
