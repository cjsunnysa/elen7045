using System;
using System.Collections.Generic;
using FaultLogging.Core.Model;
 
namespace FaultLogging.Persistence.Interfaces
{
    public interface IFaultRepository
    {
        IEnumerable<Fault> GetAllFaults();
        Fault GetFaultById(Guid id);
        IEnumerable<Fault> GetFaultsBy(SearchDTO search);
    }
}