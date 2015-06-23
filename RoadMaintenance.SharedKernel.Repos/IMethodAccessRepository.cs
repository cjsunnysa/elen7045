using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Core;

namespace RoadMaintenance.SharedKernel.Repos
{
    public interface IMethodAccessRepository
    {
        MethodAccess Find(string methodName);
        void Save(MethodAccess methodAccess);
    }
}
