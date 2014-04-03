using AngularQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private AngularQuizContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AngularQuizContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
            _dbSet = context.Set<TEntity>();
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
            //_dbSet.Attach(entity);

            var original = _dbSet.Find(entity.Id);

            if (original != null)
            {
                _context.Entry(original).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            if(filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            return List().Count(filter);
        }

        public int Count()
        {
            return List().Count();
        }
    }
}
