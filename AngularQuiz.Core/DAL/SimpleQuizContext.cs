using Microsoft.AspNet.Identity.EntityFramework;
using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AngularQuiz.Core.DAL
{
    public class AngularQuizContext : IdentityDbContext<User>
    {
        public AngularQuizContext() : base("DefaultConnection") {}

        public AngularQuizContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public DbSet<QuizPackage> QuizPackages { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        
        public DbSet<OpenQuestion> OpenQuestions { get; set; }
        public DbSet<OpenQuestionCorrectAnswer> OpenQuestionCorrectAnswers { get; set; }
        public DbSet<OpenQuestionCorrectAnswerOption> OpenQuestionCorrectAnswersOptions { get; set; }

        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestQuestionOption> TestQuestionOptions { get; set; }
        
        public DbSet<SortQuestion> SortQuestions { get; set; }
        public DbSet<SortQuestionOption> SortQuestionOptions { get; set; }

        public DbSet<CategoryQuestion> CategoryQuestions { get; set; }
        public DbSet<CategoryQuestionOption> CategoryQuestionOption { get; set; }

        public DbSet<UserQuizScorePackage> UserQuizScorePackages { get; set; }
        public DbSet<UserQuizScore> UserQuizScores { get; set; }
    }
}