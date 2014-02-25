namespace SimpleQuiz.Migrations
{
    using SimpleQuiz.Core.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SimpleQuiz.Core.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleQuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleQuizContext context)
        {
            //  This method will be called after migrating to the latest version.

            if(!context.Users.Any(u => u.UserName == "piotr"))
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var user = new User
                {
                     UserName = "piotr",
                     Email = "piotr@piotr.pl"
                };

                userManager.Create<User>(user, "P@ssw0rd");
            }

            var quizPackage = new QuizPackage { Name = "Test package" };

            context.QuizPackages.AddOrUpdate(p => p.Name, quizPackage);

            var quiz1 = new Quiz { Name = "Test quiz 1", QuizPackageId = quizPackage.Id };
            context.Quizes.AddOrUpdate(q => q.Name, quiz1);

            context.SaveChanges();
            
            var question1 = new Question 
                 { 
                     QuizId = quiz1.Id,
                     Content = "Pues muy tremenda, muy... ¡Ay! ¡Qué miedo []!"
                 };

            var question2 = new Question
            {
                QuizId = quiz1.Id,
                Content = "[] un cliente para hacerle la entrada - el check-in - como [] antes y le [] yo atendiendo y le [] un ataque."
            };

            var question3 = new Question
            {
                QuizId = quiz1.Id,
                Content = "Y se [] aquí - aquí justo delante de la recepción que Uds. no lo pueden ver, pero aquí delante...Y el cliente no []"
            };
            
            context.Questions.AddOrUpdate(q => q.Content, question1, question2, question3);
            context.SaveChanges();

            var correctAnswer1 = new QuestionCorrectAnswer { QuestionId = question1.Id };

            var correctAnswer2 = new QuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 1 };
            var correctAnswer3 = new QuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 2 };
            var correctAnswer4 = new QuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 3 };

            var correctAnswer5 = new QuestionCorrectAnswer { QuestionId = question3.Id, OrderId = 1 };
            var correctAnswer6 = new QuestionCorrectAnswer { QuestionId = question3.Id, OrderId = 2 };

            context.QuestionCorrectAnswers.AddOrUpdate(
                correctAnswer1, correctAnswer2, correctAnswer3, 
                correctAnswer4, correctAnswer5, correctAnswer6);
            context.SaveChanges();

            var correctAnswerOption1 = new QuestionCorrectAnswerOption("pasé") { QuestionCorrectAnswerId = correctAnswer1.Id };

            var correctAnswerOption2 = new QuestionCorrectAnswerOption("Vino") { QuestionCorrectAnswerId = correctAnswer2.Id };
            var correctAnswerOption3 = new QuestionCorrectAnswerOption("dije") { QuestionCorrectAnswerId = correctAnswer2.Id };
            var correctAnswerOption4 = new QuestionCorrectAnswerOption("estaba") { QuestionCorrectAnswerId = correctAnswer2.Id };

            var correctAnswerOption5 = new QuestionCorrectAnswerOption("cayó") { QuestionCorrectAnswerId = correctAnswer3.Id };
            var correctAnswerOption6 = new QuestionCorrectAnswerOption("hablaba") { QuestionCorrectAnswerId = correctAnswer3.Id };

            context.QuestionCorrectAnswersOptions.AddOrUpdate(o => o.Content, 
                correctAnswerOption1, correctAnswerOption2, correctAnswerOption3,
                correctAnswerOption4, correctAnswerOption5, correctAnswerOption6);

            context.SaveChanges();
        }
    }
}