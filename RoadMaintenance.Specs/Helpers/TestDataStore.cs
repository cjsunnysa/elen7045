using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Specs.Helpers
{
    public class TestDataStore : IDataStore<Fault>
    {
        private List<Fault> _data;
        public IQueryable<Fault> Data
        {
            get { return _data.AsQueryable(); }
        }

        public TestDataStore()
        {
            _data = new List<Fault>();
        }

        public void AppendOrUpdate(Fault record)
        {
            var existRec = _data.SingleOrDefault(f => f.Id.Equals(record.Id));
            
            if (existRec == null)
                _data.Add(record);
            else
            {
                _data.Remove(existRec);
                _data.Add(record);
            }
        }

        public void SetData(List<Fault> data)
        {
            _data = data;
        }
    }
}
