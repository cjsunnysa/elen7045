using System;
using System.Linq;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Repos
{
    public class FaultLoggingRepository : IRepository<Fault, Guid>
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

        public IQueryable<Fault> Search()
        {
            return _dataStore.Data;
        }

        public void Save(Fault entity)
        {
            _dataStore.AppendOrUpdate(entity);
        }
    }
}