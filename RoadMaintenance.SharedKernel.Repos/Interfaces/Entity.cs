﻿using RoadMaintenance.ApplicationLayer;

namespace RoadMaintenance.SharedKernel.Repos.Interfaces
{
    public abstract class Entity<TId>
    {
        public TId Id { get; internal set; }

        protected Entity(TId id)
        {
            Guard.ForNull(id, "id");

            Id = id;
        }
    }
}