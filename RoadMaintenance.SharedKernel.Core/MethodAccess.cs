using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.SharedKernel.Core
{
    public class MethodAccess : Entity<string>
    {
        public string MethodName { get { return Id; } }
        public IEnumerable<String> Roles;

        public MethodAccess(string methodName, IEnumerable<string> roles)
            :base(methodName)
        {                        
            Roles = roles;
        }

        public MethodAccess(string methodName, params string[] roles)
            :this(methodName, (IEnumerable<string>)roles) { }        
        
    }
}
