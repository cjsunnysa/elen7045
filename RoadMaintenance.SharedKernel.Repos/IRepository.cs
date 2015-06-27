using System.Linq;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.SharedKernel.Repos
{
    public interface IRepository<TDataType, in TIdDataType>
        where TDataType : Entity<TIdDataType>
    {
        TDataType Find(TIdDataType id);
        IQueryable<TDataType> Search();
        void Save(TDataType entity);
    }
}