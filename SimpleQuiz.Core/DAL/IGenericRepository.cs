using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
        IQueryable<TEntity> List();
    }
}
