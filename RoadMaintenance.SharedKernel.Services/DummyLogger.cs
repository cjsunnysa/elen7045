using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.SharedKernel.Services
{
    public class DummyLogger : ILogger
    {
        private ConcurrentDictionary<LogLevel, StringBuilder> logs = new ConcurrentDictionary<LogLevel, StringBuilder>();

        public void Log(string message, LogLevel level)
        {
            var log = logs.GetOrAdd(level, _ => new StringBuilder());
            log.AppendLine(message);
        }


        public string GetLogs(LogLevel level)
        {
            return logs.GetOrAdd(level, _ => new StringBuilder()).ToString();
        }
    }
}
