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

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleQuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed
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

            var quiz1 = new Quiz { Name = "Test quiz 1", QuizPackageId = package1.Id };
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

            var correctAnswersList = new List<QuestionCorrectAnswer>
            {
                new QuestionCorrectAnswer { QuestionId = question1.Id },

                new QuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 1 },
                new QuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 2 },
                new QuestionCorrectAnswer { QuestionId = question2.Id, OrderId = 3 },

                new QuestionCorrectAnswer { QuestionId = question3.Id, OrderId = 1 },
                new QuestionCorrectAnswer { QuestionId = question3.Id, OrderId = 2 }
            };

            correctAnswersList.ForEach(a =>
            {
                var toRemove = context.QuestionCorrectAnswers.SingleOrDefault(x => x.OrderId == a.OrderId && x.QuestionId == a.QuestionId); 
                if(toRemove != null)
                {
                    context.QuestionCorrectAnswers.Remove(toRemove);
                    context.SaveChanges();
                }
            });
           
            context.QuestionCorrectAnswers.AddRange(correctAnswersList);
            context.SaveChanges();

            var correctAnswerOption1 = new QuestionCorrectAnswerOption("pasé") { QuestionCorrectAnswerId = correctAnswersList[0].Id };

            var correctAnswerOption2 = new QuestionCorrectAnswerOption("Vino") { QuestionCorrectAnswerId = correctAnswersList[1].Id };
            var correctAnswerOption3 = new QuestionCorrectAnswerOption("dije") { QuestionCorrectAnswerId = correctAnswersList[2].Id };
            var correctAnswerOption4 = new QuestionCorrectAnswerOption("estaba") { QuestionCorrectAnswerId = correctAnswersList[3].Id };

            var correctAnswerOption5 = new QuestionCorrectAnswerOption("cayó") { QuestionCorrectAnswerId = correctAnswersList[4].Id };
            var correctAnswerOption6 = new QuestionCorrectAnswerOption("hablaba") { QuestionCorrectAnswerId = correctAnswersList[5].Id };

            context.QuestionCorrectAnswersOptions.AddOrUpdate(o => o.Content, 
                correctAnswerOption1, correctAnswerOption2, correctAnswerOption3,
                correctAnswerOption4, correctAnswerOption5, correctAnswerOption6);

            context.SaveChanges();
        }
    }
}