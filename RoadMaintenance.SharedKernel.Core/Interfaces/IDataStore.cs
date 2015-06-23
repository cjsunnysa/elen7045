using System.Collections.Generic;
using System.Linq;

namespace RoadMaintenance.SharedKernel.Core.Interfaces
{
    public interface IDataStore<TDataType>
    {
        IQueryable<TDataType> Data { get; }
        void AppendOrUpdate(TDataType record);
    }
}