namespace NgQuiz.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NgQuiz.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NgQuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NgQuizContext context)
        {
            context.Phrases.AddOrUpdate(p => p.Content,
                new Phrase { Content = "suave", Translation = "soft, smooth", DateAdded = DateTime.Now },
                new Phrase { Content = "lograr", Translation = "manage, achieve", DateAdded = DateTime.Now },
                new Phrase { Content = "ampliar", Translation = "increase", DateAdded = DateTime.Now },
                new Phrase { Content = "contener la respiracion", Translation = "hold your breath", DateAdded = DateTime.Now },
                new Phrase { Content = "puro y duro", Translation = "harsh (reality)", DateAdded = DateTime.Now });

            context.SaveChanges();
        }
    }
}
