using System.Collections.Generic;

namespace RoadMaintenance.FaultLogging.Repos.Interfaces
{
    public interface IDataStore<out TDataType>
    {
        IEnumerable<TDataType> GetAllData();
    }
}