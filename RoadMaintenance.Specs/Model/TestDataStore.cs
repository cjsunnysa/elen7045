using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Specs.Model
{
    public class TestDataStore : IDataStore<Fault>
    {
        private readonly List<Fault> _data;
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
            _data.Add(record);
        }
    }
}
