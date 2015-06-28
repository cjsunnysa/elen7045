using RoadMaintenance.FaultVerification.Core.Model;
using RoadMaintenance.FaultVerification.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMaintenance.FaultVerification.Services.Interfaces
{
    public interface IFaultService
    {
        IEnumerable<FaultView> GetJurisdictionFaults(GetJuristdictionFaultsRequest request);
    }
}
