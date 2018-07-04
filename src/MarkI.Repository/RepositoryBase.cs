using System;
using System.Collections.Generic;
using System.Linq;
using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private ApplicationContext _applicationContext;

        public RepositoryBase(ApplicationContext aplicationContext)
        {
            _applicationContext = aplicationContext;
        }

        public bool Add(TEntity entity)
        {
    
            _applicationContext.Set<TEntity>().Add(entity);
            var result = _applicationContext.SaveChanges() > 0;
            _applicationContext.Dispose();

            return result;
        }

        public TEntity GetById(string id)
        {
            var query =_applicationContext.Set<TEntity>().FirstOrDefault(entity => entity.Id.Equals(id));
            return query; 
        }
    }
}