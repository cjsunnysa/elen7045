using System;
using System.Collections.Generic;
using System.Linq;
using FaultLogging.Core.Model;
using FaultLogging.Persistence.Interfaces;

namespace FaultLogging.Persistence
{
    public class FaultRepository : IFaultRepository
    {
        private readonly IDataStore<Fault> _dataStore;

        public FaultRepository(IDataStore<Fault> dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Fault> GetAllFaults()
        {
            return _dataStore.GetAllData();
        }

        public Fault GetFaultById(Guid id)
        {
            return _dataStore.GetAllData().SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fault> GetFaultsBy(SearchDTO search)
        {
            return _dataStore.GetAllData().Where(data =>
                (string.IsNullOrEmpty(search.Street1) || data.Address.Street.ToLower().Contains(search.Street1.ToLower()) || data.Address.CrossStreet.ToLower().Contains(search.Street1.ToLower())) &&
                (string.IsNullOrEmpty(search.Street2) || data.Address.Street.ToLower().Contains(search.Street2.ToLower()) || data.Address.CrossStreet.ToLower().Contains(search.Street2.ToLower())) &&
                (string.IsNullOrEmpty(search.Suburb)  || data.Address.Suburb.ToLower().Contains(search.Suburb.ToLower())) &&
                (search.TypeId == null || (int) data.Type == search.TypeId));
        }
    }
}