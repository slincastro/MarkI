using System.Collections.Generic;
using MarkI.Domain;

namespace MarkI.IRepository
{
    public interface IRepositoryBase<TEntity>
    {
         void Add(TEntity entity);
         TEntity GetById(string number);
    }
}