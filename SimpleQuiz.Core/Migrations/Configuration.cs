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
            AddSampleUsers(context);

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

            AddOpenQuestions(context, quiz1);
            AddTestQuestions(context, quiz1);
            AddCategoryQuestions(context, quiz1);
            AddSortQuestions(context, quiz1);
        }

        private static void AddSampleUsers(SimpleQuizContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (!context.Users.Any(u => u.UserName == "piotr"))
            {
                var user = new User
                {
                    UserName = "piotr",
                    Email = "piotr@piotr.pl"
                };

                userManager.Create(user, "P@ssw0rd");
            }

            if(!context.Users.Any(u => u.UserName == "admin"))
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = "piotr@piotr.pl"
                };

                userManager.Create(admin, "P@ssw0rd");
                userManager.AddToRole(admin.Id, "admin");
            }
        }

        private static void AddOpenQuestions(SimpleQuizContext context, Quiz quiz)
        {
            var question1 = new OpenQuestion
            {
                QuizId = quiz.Id,
                Content = "Pues muy tremenda, muy... ¡Ay! ¡Qué miedo []!",
                View = "OpenQuestionStandard"
            };

            var question2 = new OpenQuestion
            {
                QuizId = quiz.Id,
                Content = "[] un cliente para hacerle la entrada - el check-in - como [] antes y le [] yo atendiendo y le [] un ataque.",
                View = "OpenQuestionStandard"
            };

            var question3 = new OpenQuestion
            {
                QuizId = quiz.Id,
                Content = "Y se [] aquí - aquí justo delante de la recepción que Uds. no lo pueden ver, pero aquí delante...Y el cliente no []",
                View = "OpenQuestionStandard"
            };

            context.OpenQuestions.AddOrUpdate(q => q.Content, question1, question2, question3);
            context.SaveChanges();

            var correctAnswersList = new List<OpenQuestionCorrectAnswer>
            {
                new OpenQuestionCorrectAnswer { OpenQuestionId = question1.Id },
                new OpenQuestionCorrectAnswer { OpenQuestionId = question2.Id, OrderId = 1 },
                new OpenQuestionCorrectAnswer { OpenQuestionId = question2.Id, OrderId = 2 },
                new OpenQuestionCorrectAnswer { OpenQuestionId = question2.Id, OrderId = 3 },
                new OpenQuestionCorrectAnswer { OpenQuestionId = question3.Id, OrderId = 1 },
                new OpenQuestionCorrectAnswer { OpenQuestionId = question3.Id, OrderId = 2 }
            };

            correctAnswersList.ForEach(a =>
            {
                var toRemove = context.OpenQuestionCorrectAnswers.SingleOrDefault(x => x.OrderId == a.OrderId && x.OpenQuestionId == a.OpenQuestionId);
                if (toRemove != null)
                {
                    context.OpenQuestionCorrectAnswers.Remove(toRemove);
                    context.SaveChanges();
                }
            });

            context.OpenQuestionCorrectAnswers.AddRange(correctAnswersList);
            context.SaveChanges();

            var options = new List<OpenQuestionCorrectAnswerOption>
            {
                new OpenQuestionCorrectAnswerOption("pasé") { OpenQuestionCorrectAnswerId = correctAnswersList[0].Id },
                new OpenQuestionCorrectAnswerOption("Vino") { OpenQuestionCorrectAnswerId = correctAnswersList[1].Id },
                new OpenQuestionCorrectAnswerOption("dije") { OpenQuestionCorrectAnswerId = correctAnswersList[2].Id },
                new OpenQuestionCorrectAnswerOption("estaba") { OpenQuestionCorrectAnswerId = correctAnswersList[3].Id },
                new OpenQuestionCorrectAnswerOption("cayó") { OpenQuestionCorrectAnswerId = correctAnswersList[4].Id },
                new OpenQuestionCorrectAnswerOption("hablaba") { OpenQuestionCorrectAnswerId = correctAnswersList[5].Id },
                new OpenQuestionCorrectAnswerOption("Hablaba") { OpenQuestionCorrectAnswerId = correctAnswersList[5].Id }
            };

            context.OpenQuestionCorrectAnswersOptions.AddOrUpdate(o => o.Content, options.ToArray());
            context.SaveChanges();
        }

        private static void AddTestQuestions(SimpleQuizContext context, Quiz quiz)
        {
            var question1 = new TestQuestion() { Content = "He llegado [ ] 5 minutos.", OrderId = 6, QuizId = quiz.Id, View = "TestQuestionStandard" };
            context.TestQuestions.AddOrUpdate(q => q.Content, question1);

            context.SaveChanges();

            var options = new List<TestQuestionOption>
            {
                new TestQuestionOption { Content = "hace", IsCorrect = true, TestQuestionId = question1.Id },
                new TestQuestionOption { Content = "hadd", IsCorrect = false, TestQuestionId = question1.Id },
                new TestQuestionOption { Content = "hasd", IsCorrect = false, TestQuestionId = question1.Id }
            };

            context.TestQuestionOptions.AddOrUpdate(o => o.Content, options.ToArray());
            context.SaveChanges();
        }

        private static void AddCategoryQuestions(SimpleQuizContext context, Quiz quiz)
        {
            var question1 = new CategoryQuestion { Content = "Alphabet or number or bird?", QuizId = quiz.Id, OrderId = 9, View = "Standard" };

            context.CategoryQuestions.Add(question1);
            context.SaveChanges();

            var options = new List<CategoryQuestionOption>
            {
                new CategoryQuestionOption { Category = "Alphabet", Content = "A", CategoryQuestionId = question1.Id },
                new CategoryQuestionOption { Category = "Alphabet", Content = "B", CategoryQuestionId = question1.Id },
                new CategoryQuestionOption { Category = "Number", Content = "1234", CategoryQuestionId = question1.Id },
                new CategoryQuestionOption { Category = "Bird", Content = "hen", CategoryQuestionId = question1.Id },
                new CategoryQuestionOption { Category = "Number", Content = "-2302.5443", CategoryQuestionId = question1.Id }
            };

            context.CategoryQuestionOption.AddOrUpdate(o => o.Content, options.ToArray());
            context.SaveChanges();
        }

        private static void AddSortQuestions(SimpleQuizContext context, Quiz quiz)
        {
            var question1 = new SortQuestion { Content = "Sort the dialogue", QuizId = quiz.Id, View = "Standard", OrderId = 8 };

            context.SortQuestions.Add(question1);
            context.SaveChanges();

            var options = new List<SortQuestionOption>
            {
                new SortQuestionOption { Content = "Hola, por favor siéntese en la silla.", SortQuestionId = question1.Id, OrderId = 1 },
                new SortQuestionOption { Content = "Tengo un dolor de muelas terrible.", SortQuestionId = question1.Id, OrderId = 2 },
                new SortQuestionOption { Content = "¿Hace cuánto tiempo tiene el dolor?", SortQuestionId = question1.Id, OrderId = 3 },
                new SortQuestionOption { Content = "Hace varios días.", SortQuestionId = question1.Id, OrderId = 4 },
                new SortQuestionOption { Content = "¿Ha tenido este tipo de dolor antes?", SortQuestionId = question1.Id, OrderId = 5 },
                new SortQuestionOption { Content = "¿En dónde exactamente tiene el dolor?", SortQuestionId = question1.Id, OrderId = 6 },
                new SortQuestionOption { Content = "Me duele el diente.", SortQuestionId = question1.Id, OrderId = 7 },
                new SortQuestionOption { Content = "Por favor abra su boca.", SortQuestionId = question1.Id, OrderId = 8 },
                new SortQuestionOption { Content = "Vamos a tener que sacar el diente.", SortQuestionId = question1.Id, OrderId = 9 },
                new SortQuestionOption { Content = "La anestesia local hará que no duela.", SortQuestionId = question1.Id, OrderId = 10 },
                new SortQuestionOption { Content = "Muchas gracias, Doctor.", SortQuestionId = question1.Id, OrderId = 11 }
            };

            options.ForEach(option => context.SortQuestionOptions.AddOrUpdate(o => o.Content, options.ToArray()));
            context.SaveChanges();
        }
    }
}