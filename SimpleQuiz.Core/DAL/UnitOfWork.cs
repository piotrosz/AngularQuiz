using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleQuizContext _context;
        private GenericRepository<QuizPackage> _quizPackageRepository;
        private GenericRepository<Quiz> _quizRepository;
        private GenericRepository<OpenQuestion> _openQuestionRepository;
        private GenericRepository<TestQuestion> _testQuestionRepository;

        public UnitOfWork()
        {
            _context = new SimpleQuizContext();
        }

        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new SimpleQuizContext(nameOrConnectionString);
        }

        private GenericRepository<T> GetRepositoryLazy<T>(GenericRepository<T> repository)
            where T : Entity
        {
            return repository ?? (repository = new GenericRepository<T>(_context));
        }

        public IGenericRepository<QuizPackage> QuizPackage
        {
            get { return GetRepositoryLazy(_quizPackageRepository); }
        }

        public IGenericRepository<Quiz> Quiz
        {
            get { return GetRepositoryLazy(_quizRepository); }
        }

        public IGenericRepository<OpenQuestion> OpenQuestion
        {
            get { return GetRepositoryLazy(_openQuestionRepository);  }
        }

        public IGenericRepository<TestQuestion> TestQuestion
        {
            get { return GetRepositoryLazy(_testQuestionRepository); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
