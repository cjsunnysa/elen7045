using System.Collections.Generic;
using System.Linq;

namespace RoadMaintenance.SharedKernel.Repos.Interfaces
{
    public interface IRepository<TDataType, in TIdDataType>
        where TDataType : Entity<TIdDataType>
    {
        TDataType Find(TIdDataType id);
        void Save(TDataType entity);
    }
}