using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.SharedKernel.Core
{
    public class User
    {
        public readonly string Role;

        public User(string role)
        {
            Role = role;
        }
    }
}
