using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadMaintenance.SharedKernel.Core.Interfaces;

namespace RoadMaintenance.SharedKernel.Repos
{
    public abstract class DummyRepo<TId, TEntity> : IRepository<TId, TEntity> where TEntity : Entity<TId>
    {        
        protected Dictionary<TId, TEntity> entityMap;

        protected DummyRepo()
        {
            entityMap = new Dictionary<TId, TEntity>();       
        }

        protected DummyRepo(IEnumerable<TEntity> initialEntities)
        {
            entityMap = initialEntities.ToDictionary(entity => entity.Id);
        }
        

        public TEntity Find(TId id)
        {
            if (entityMap.ContainsKey(id))
                return entityMap[id];

            return null;
        }

        public void Save(TEntity entity)
        {
            entityMap[entity.Id] = entity;
        }
    }
}
