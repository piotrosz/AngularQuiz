using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AngularQuizContext _context;
        private GenericRepository<QuizPackage> _quizPackageRepository;
        private GenericRepository<Quiz> _quizRepository;
        private GenericRepository<OpenQuestion> _openQuestionRepository;
        private GenericRepository<TestQuestion> _testQuestionRepository;
        private GenericRepository<CategoryQuestion> _categoryQuestionRepository;
        private GenericRepository<SortQuestion> _sortQuestionRepository;

        public UnitOfWork()
        {
            _context = new AngularQuizContext();
        }

        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new AngularQuizContext(nameOrConnectionString);
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

        public IGenericRepository<CategoryQuestion> CategoryQuestion
        {
            get { return GetRepositoryLazy(_categoryQuestionRepository); }
        }

        public IGenericRepository<SortQuestion> SortQuestion
        {
            get { return GetRepositoryLazy(_sortQuestionRepository); }
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
