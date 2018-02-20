using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Learning.BusinessLogic.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Learning.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public LearningContext _ctx;
        internal DbSet<T> dbSet;
        public BaseRepository(LearningContext ctx)
        {
            _ctx = ctx;
            this.dbSet = _ctx.Set<T>();
        }

        public T Add(T newEntity)
        {
            T savedEntity = this.dbSet.Add(newEntity);
            _ctx.SaveChanges();
            return savedEntity;
        }

        public T FindFirst(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate).FirstOrDefault();
        }

        public async Task<T> Get(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate = null)
        {
            return this.dbSet;
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
