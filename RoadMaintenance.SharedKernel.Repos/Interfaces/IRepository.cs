using System.Linq;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.SharedKernel.Repos.Interfaces
{
    public interface IRepository<in TIdDataType, TDataType>
        where TDataType : Entity<TIdDataType>
    {
        TDataType Find(TIdDataType id);        
        void Save(TDataType entity);
    }
}