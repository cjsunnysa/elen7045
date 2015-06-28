using System;
using System.Collections.Generic;
using System.Linq;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Core.Model;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.SharedKernel.Core.Interfaces;
using RoadMaintenance.SharedKernel.Repos;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.FaultLogging.Repos
{
    public class DummyFaultRepository : DummyRepo<Guid, Fault>, IFaultRepository
    {
        public DummyFaultRepository() : base()
        { }

        public DummyFaultRepository(IEnumerable<Fault> data) : base(data)
        { }

        public void SetData(List<Fault> data)
        {
            entityMap = data.ToDictionary(entity => entity.Id);
        }

        public IEnumerable<Fault> SearchForRecentFaults(string street1, string street2, string suburb, Type? type, DateTime? repairedPeriod)
        {
            var lowerStreet1 = string.IsNullOrEmpty(street1)
                          ? null
                          : street1.ToLower();

            var lowerStreet2 = string.IsNullOrEmpty(street2)
                          ? null
                          : street2.ToLower();

            var lowerSuburb = string.IsNullOrEmpty(suburb)
                          ? null
                          : suburb.ToLower();
            
            return from d in entityMap.AsQueryable()
                   let s = d.Value.Address.Street.ToLower()
                   let cs = d.Value.Address.CrossStreet.ToLower()
                   let sub = d.Value.Address.Suburb.ToLower()
                   where
                       (lowerStreet1 == null || s.Contains(lowerStreet1) || cs.Contains(lowerStreet1)) &&
                       (lowerStreet2 == null || s.Contains(lowerStreet2) || cs.Contains(lowerStreet2)) &&
                       (lowerSuburb == null || sub.Contains(lowerSuburb)) &&
                       (type == null || d.Value.Type == type) &&
                       (d.Value.Status != Status.Repaired ||
                            (repairedPeriod != null && d.Value.DateCompleted != null && d.Value.DateCompleted >= (DateTime)repairedPeriod))
                   select d.Value;
        }
    }
}