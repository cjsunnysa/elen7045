namespace RoadMaintenance.DataService.Interfaces
{
    public interface IRepository<out TDataType>
    {
        TDataType SelectById(int id);
        TDataType[] SelectAll();
    }
}