using System.Linq;

namespace RoadMaintenance.SharedKernel.Core.Interfaces
{
    public interface IRepository<TDataType, in TIdDataType>
        where TDataType : Entity<TIdDataType>
    {
        TDataType Find(TIdDataType id);
        IQueryable<TDataType> Search();
        void Save(TDataType entity);
    }
}