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
    using System.Collections.Generic;
    using SimpleQuiz.Core.Model.Questions;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleQuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
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

            var package1 = new QuizPackage { Name = "El Sustantivo" };
            var package2 = new QuizPackage { Name = "Los Posesivos" };
            var package3 = new QuizPackage { Name = "Demostrativos" };
            var package4 = new QuizPackage { Name = "Pronombres Personales Reflexivos" };
            var package5 = new QuizPackage { Name =  "Futuro Próximo" };
            var package6 = new QuizPackage { Name = "Preposición + Pronombre Personal" };
            var package7 = new QuizPackage { Name = "Pretérito Perfecto" };
            var package8 = new QuizPackage { Name = "Presente Continuo (Estar + Gerundio)" };
            var package9 = new QuizPackage { Name = "Pronombres y Adjetivos Indefinidos" };
            var package10 = new QuizPackage { Name = "Verbos Intransitivos" };
            var package11 = new QuizPackage { Name = "Preposiciones" };

            context.QuizPackages.AddOrUpdate(p => p.Name, package1, package2, package3, package4,
                package5, package6, package7, package8, package9, package10, package11);
            
            context.SaveChanges();

            var quiz1 = new Quiz { Name = "Test quiz 1", QuizPackageId = package1.Id, View = "Standard"  };
            context.Quizes.AddOrUpdate(q => q.Name, quiz1);

            context.SaveChanges();
            
            var question1 = new OpenQuestion 
                 { 
                     QuizId = quiz1.Id,
                     Content = "Pues muy tremenda, muy... ¡Ay! ¡Qué miedo []!",
                     View = "OpenQuestionStandard"
                 };

            var question2 = new OpenQuestion
            {
                QuizId = quiz1.Id,
                Content = "[] un cliente para hacerle la entrada - el check-in - como [] antes y le [] yo atendiendo y le [] un ataque.",
                View = "OpenQuestionStandard"
            };

            var question3 = new OpenQuestion
            {
                QuizId = quiz1.Id,
                Content = "Y se [] aquí - aquí justo delante de la recepción que Uds. no lo pueden ver, pero aquí delante...Y el cliente no []",
                View = "OpenQuestionStandard"
            };
            
            context.OpenQuestions.AddOrUpdate(q => q.Content, question1, question2, question3);
            context.SaveChanges();

            var correctAnswersList = new List<OpenQuestionCorrectAnswer>
            {
                new OpenQuestionCorrectAnswer { QuestionId = question1.Id },

                new OpenQuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 1 },
                new OpenQuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 2 },
                new OpenQuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 3 },

                new OpenQuestionCorrectAnswer { QuestionId = question3.Id, OrderId = 1 },
                new OpenQuestionCorrectAnswer { QuestionId = question3.Id, OrderId = 2 }
            };

            correctAnswersList.ForEach(a =>
            {
                var toRemove = context.OpenQuestionCorrectAnswers.SingleOrDefault(x => x.OrderId == a.OrderId && x.QuestionId == a.QuestionId); 
                if(toRemove != null)
                {
                    context.OpenQuestionCorrectAnswers.Remove(toRemove);
                    context.SaveChanges();
                }
            });
           
            context.OpenQuestionCorrectAnswers.AddRange(correctAnswersList);
            context.SaveChanges();

            var correctAnswerOption1 = new OpenQuestionCorrectAnswerOption("pasé") { OpenQuestionCorrectAnswerId = correctAnswersList[0].Id };

            var correctAnswerOption2 = new OpenQuestionCorrectAnswerOption("Vino") { OpenQuestionCorrectAnswerId = correctAnswersList[1].Id };
            var correctAnswerOption3 = new OpenQuestionCorrectAnswerOption("dije") { OpenQuestionCorrectAnswerId = correctAnswersList[2].Id };
            var correctAnswerOption4 = new OpenQuestionCorrectAnswerOption("estaba") { OpenQuestionCorrectAnswerId = correctAnswersList[3].Id };

            var correctAnswerOption5 = new OpenQuestionCorrectAnswerOption("cayó") { OpenQuestionCorrectAnswerId = correctAnswersList[4].Id };
            var correctAnswerOption6 = new OpenQuestionCorrectAnswerOption("hablaba") { OpenQuestionCorrectAnswerId = correctAnswersList[5].Id };

            context.OpenQuestionCorrectAnswersOptions.AddOrUpdate(o => o.Content, 
                correctAnswerOption1, correctAnswerOption2, correctAnswerOption3,
                correctAnswerOption4, correctAnswerOption5, correctAnswerOption6);

            context.SaveChanges();

            var testQuestion1 = new TestQuestion() { Content = "He llegado [ ] 5 minutos.", OrderId = 6, QuizId = quiz1.Id, View = "TestQuestionStandard" };
            context.TestQuestions.AddOrUpdate(q => q.Content, testQuestion1);

            context.SaveChanges();

            var testOption1 = new TestQuestionOption { Content = "hace", IsCorrect = true, QuestionId = testQuestion1.Id };
            var testOption2 = new TestQuestionOption { Content = "hadd", IsCorrect = false, QuestionId = testQuestion1.Id };
            var testOption3 = new TestQuestionOption { Content = "hasd", IsCorrect = false, QuestionId = testQuestion1.Id };
            context.TestQuestionOptions.AddOrUpdate(o => o.Content, testOption1);
            context.TestQuestionOptions.AddOrUpdate(o => o.Content, testOption2);
            context.TestQuestionOptions.AddOrUpdate(o => o.Content, testOption3);

            context.SaveChanges();
        }
    }
}