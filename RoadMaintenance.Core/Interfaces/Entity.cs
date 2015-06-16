using RoadMaintenance.ApplicationLayer;

namespace RoadMaintenance.FaultLogging.Core.Interfaces
{
    public abstract class Entity<TId>
    {
        public TId Id { get; private set; }

        protected Entity(TId id)
        {
            Guard.ForNull(id, "id");

            Id = id;
        }
    }
}
