using SimpleQuiz.Core.Model;
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
