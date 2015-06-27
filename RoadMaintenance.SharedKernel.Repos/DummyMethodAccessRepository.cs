using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Core;

namespace RoadMaintenance.SharedKernel.Repos
{
    public class DummyMethodAccessRepository : DummyRepo<string, MethodAccess>, IMethodAccessRepository
    {        
        public DummyMethodAccessRepository()
            : base()
        {
            
        }

        public DummyMethodAccessRepository(IEnumerable<MethodAccess> initialMethodAccess)
            : base(initialMethodAccess)
        {
            
        }
    }
}
