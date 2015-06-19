namespace RoadMaintenance.SharedKernel.Core.Interfaces
{
    public interface IRepository<TDataType, in TIdDataType>
        where TDataType : Entity<TIdDataType>
    {
        TDataType Find(TIdDataType id);
        void Save(TDataType entity);
    }
}