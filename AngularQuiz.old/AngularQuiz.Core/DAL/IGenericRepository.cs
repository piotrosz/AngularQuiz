using AngularQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
        void Attach(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> List();
        int Count(Expression<Func<TEntity, bool>> filter);
        int Count();
    }
}
