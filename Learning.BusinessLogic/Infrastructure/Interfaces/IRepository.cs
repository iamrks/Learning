using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.BusinessLogic.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Func<TEntity, bool> predicate = null);
        Task<TEntity> Get(int id);
        TEntity Add(TEntity newEntity);
        void Remove(TEntity entity);
        TEntity FindFirst(Expression<Func<TEntity, bool>> predicate);
    }
}
