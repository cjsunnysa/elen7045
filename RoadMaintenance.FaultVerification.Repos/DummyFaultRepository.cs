using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.FaultVerification.Core;
using RoadMaintenance.FaultVerification.Core.Model;
using RoadMaintenance.FaultVerification.Repos.Interfaces;

namespace RoadMaintenance.FaultVerification.Repos
{
    public class DummyFaultRepository : DummyRepo<Guid, Fault>, IFaultRepository
    {
        public DummyFaultRepository()
            : base()
        { }

        public DummyFaultRepository(IEnumerable<Fault> data)
            : base(data)
        { }

        public void SetData(List<Fault> data)
        {
            entityMap = data.ToDictionary(entity => entity.Id);
        }

        public IEnumerable<Fault> SearchForFaultsInJurisdiction()
        {
            var result = new List<Fault>();

            foreach (var item in entityMap)
            {
                result.Add(item.Value);
            }
            //return entityMap.Select<Fault>;

            return result;
        }
    }
}
