using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.FaultLogging.Core.Enums;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using Type = RoadMaintenance.FaultLogging.Core.Enums.Type;

namespace RoadMaintenance.SharedKernel.Services
{
    public class FaultService
    {
        private readonly IFaultLoggingRepository _repository;

        public FaultService(IFaultLoggingRepository repository)
        {
            _repository = repository;
        }

        public Type GetType(string description)
        {
            switch (description)
            {
                case "Pothole": return Type.Pothole;
                case "Faulty Traffic Light": return Type.FaultyTrafficLight;
                case "Road Marking": return Type.RoadMarking;
                default: throw new ArgumentOutOfRangeException("description", string.Format("{0} is not a fault type.", description));
            }
        }
    }
}
