using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadMaintenance.SharedKernel.Repos
{
    public abstract class DummyRepo<TId, TEntity> where TEntity : class 
    {
        protected abstract Func<TEntity, TId> getId { get; }
        protected Dictionary<TId, TEntity> entityMap;

        protected DummyRepo()
        {
            entityMap = new Dictionary<TId, TEntity>();       
        }

        protected DummyRepo(IEnumerable<TEntity> initialEntities)
        {
            entityMap = initialEntities.ToDictionary(entity => getId(entity));
        }

        public TEntity Find(TId id)
        {
            if (entityMap.ContainsKey(id))
                return entityMap[id];

            return null;
        }

        public void Save(TEntity entity)
        {
            entityMap[getId(entity)] = entity;
        }
    }
}
