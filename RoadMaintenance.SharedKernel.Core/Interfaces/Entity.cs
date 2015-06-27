using RoadMaintenance.ApplicationLayer;

namespace RoadMaintenance.SharedKernel.Core.Interfaces
{
    public abstract class Entity<TId>
    {
        public readonly TId Id;

        protected Entity(TId id)
        {
            Guard.ForNull(id, "id");

            Id = id;
        }
    }
}
