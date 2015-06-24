using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.FaultLogging.Repos
{
    public class DummyFaultRepository : IFaultRepository
    {
        private List<Fault> _data;

        public DummyFaultRepository()
        {
            _data = new List<Fault>();
        }

        public DummyFaultRepository(List<Fault> data)
        {
            _data = data;
        }

        public void SetData(List<Fault> data)
        {
            _data = data;
        }

        public Fault Find(Guid id)
        {
            return _data.SingleOrDefault(d => d.Id.Equals(id));
        }

        public IQueryable<Fault> Search()
        {
            return _data.AsQueryable();
        }

        public void Save(Fault entity)
        {
            var existRec = _data.SingleOrDefault(f => f.Id.Equals(entity.Id));
            if (existRec == null)
                _data.Add(entity);
            else
            {
                _data.Remove(entity);
                _data.Add(entity);
            }
        }
    }
}