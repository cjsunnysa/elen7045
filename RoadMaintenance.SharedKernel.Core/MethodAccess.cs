using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.SharedKernel.Core
{
    public class MethodAccess
    {        
        public readonly string MethodName;
        public IEnumerable<String> Roles;

        public MethodAccess(string methodName, IEnumerable<string> roles)
        {            
            MethodName = methodName;
            Roles = roles;
        }
    }
}
