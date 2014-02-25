using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private SimpleQuizContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(SimpleQuizContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.Configuration.LazyLoadingEnabled = false;

            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual IQueryable<TEntity> List()
        {
            IQueryable<TEntity> query = _dbSet;
            
            return query;
        }

        public void Attach(TEntity entity)
        {
            //_context.Entry<TEntity>(entity).State = EntityState.Modified;
            _dbSet.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
