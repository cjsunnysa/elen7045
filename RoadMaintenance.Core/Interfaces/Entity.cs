using System;
using FaultLogging.Core.Shared;


namespace FaultLogging.Core.Interfaces
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
