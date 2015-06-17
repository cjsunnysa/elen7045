using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.ApplicationLayer;
using RoadMaintenance.FaultLogging.Core.DTO;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.SharedKernel.Repos.Interfaces;

namespace RoadMaintenance.FaultLogging.Repos
{
    public class FaultLoggingRepository : IFaultLoggingRepository
    {
        private readonly IDataStore<Fault> _dataStore;

        public FaultLoggingRepository(IDataStore<Fault> dataStore)
        {
            _dataStore = dataStore;
        }

        public Fault Find(Guid id)
        {
            return _dataStore.Data.SingleOrDefault(d => d.Id.Equals(id));
        }


        public IEnumerable<Fault> Find(FaultSearchRequest searchRequest)
        {
            Guard.AllArgumentNotNullOrEmpty(new object[] {searchRequest.Street1, searchRequest.Street2, searchRequest.Suburb, searchRequest.TypeId}, "searchRequest");
            
            var street1 = string.IsNullOrEmpty(searchRequest.Street1)
                          ? null
                          : searchRequest.Street1.ToLower();

            var street2 = string.IsNullOrEmpty(searchRequest.Street2)
                          ? null
                          : searchRequest.Street2.ToLower();

            var suburb =  string.IsNullOrEmpty(searchRequest.Suburb)
                          ? null
                          : searchRequest.Suburb.ToLower();

            
            return from d in _dataStore.Data
                   let s = d.Address.Street.ToLower()
                   let cs = d.Address.CrossStreet.ToLower()
                   let sub = d.Address.Suburb.ToLower()
                   where
                       (street1 == null  || s.Contains(street1) || cs.Contains(street1)) &&
                       (street2 == null  || s.Contains(street2) || cs.Contains(street2)) &&
                       (suburb  == null  || sub.Contains(suburb)) &&
                       (searchRequest.TypeId == null || (int) d.Type == searchRequest.TypeId)
                   select d;
        }

        public void Save(Fault entity)
        {
            _dataStore.AppendOrUpdate(entity);
        }
    }
}