using System.Collections.Generic;

namespace FaultLogging.Persistence.Interfaces
{
    public interface IDataStore<out TDataType>
    {
        IEnumerable<TDataType> GetAllData();
    }
}