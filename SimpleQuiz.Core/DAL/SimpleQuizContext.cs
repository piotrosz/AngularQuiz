using Microsoft.AspNet.Identity.EntityFramework;
using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SimpleQuiz.Core.DAL
{
    public class SimpleQuizContext : IdentityDbContext<ApplicationUser>
    {
        public SimpleQuizContext() : base("DefaultConnection") {}

        public SimpleQuizContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

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
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCorrectAnswer> QuestionCorrectAnswers { get; set; }
        public DbSet<QuestionCorrectAnswerOption> QuestionCorrectAnswersOptions { get; set; }

        public DbSet<UserQuizScorePackage> UserQuizScorePackages { get; set; }
        public DbSet<UserQuizScore> UserQuizScores { get; set; }
    }
}