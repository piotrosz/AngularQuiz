using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NgQuiz.Web.Models
{
    public class NgQuizContext : DbContext
    {
        public NgQuizContext() : base("DefaultConnection")
        {

        }

        public DbSet<Phrase> Phrases { get; set; }
    }
}