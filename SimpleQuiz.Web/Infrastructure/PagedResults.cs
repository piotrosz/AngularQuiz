using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleQuiz.Web.Infrastructure
{
    public class PagedResults<TEntity>
    {
        public IEnumerable<TEntity> List { get; set; }
        public int TotalCount { get; set; }
    }
}