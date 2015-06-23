using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.SharedKernel.Services
{
    public enum LogLevel
    {
        Audit = 1, 
        Error = 2, 
        Info = 3, 
        Debug = 4
    }
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}
