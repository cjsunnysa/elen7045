﻿using System.Linq;

namespace RoadMaintenance.SharedKernel.Repos
{
    public interface IRepository<in TId, TEntity>
        where TEntity: class
    {
        TEntity Find(TId id);
        void Save(TEntity entity);
    }
}