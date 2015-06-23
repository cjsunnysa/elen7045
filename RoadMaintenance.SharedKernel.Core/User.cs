using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.SharedKernel.Core
{
    public interface IUser
    {
        string Role { get; }
    }

    public class User : IUser
    {
        public string Role { get; protected set; }

        public User(string role)
        {
            Role = role;
        }
    }
}
