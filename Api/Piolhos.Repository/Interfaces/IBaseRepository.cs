using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Piolhos.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
    }
}
