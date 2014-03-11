using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Quiz> Quiz { get; }
        IGenericRepository<QuizPackage> QuizPackage { get; }
        // TODO

        void Save();
    }
}
