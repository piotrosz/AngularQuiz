using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Quiz> Quiz { get; }
        IGenericRepository<QuizPackage> QuizPackage { get; }
        IGenericRepository<OpenQuestion> OpenQuestion { get; }
        IGenericRepository<TestQuestion> TestQuestion { get; }
        IGenericRepository<CategoryQuestion> CategoryQuestion { get; }
        IGenericRepository<SortQuestion> SortQuestion { get; }
        IGenericRepository<TestQuestionOption> TestQuestionOption { get; }

        void Save();
    }
}
