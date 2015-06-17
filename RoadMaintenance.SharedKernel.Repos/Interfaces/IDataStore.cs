using System.Linq;

namespace RoadMaintenance.SharedKernel.Repos.Interfaces
{
    public interface IDataStore<TDataType>
    {
        IQueryable<TDataType> Data { get; }
        void AppendOrUpdate(TDataType record);
    }
}