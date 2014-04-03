using Breeze.WebApi2;
using Breeze.ContextProvider.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NgQuiz.Web.Models;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace NgQuiz.Web.Controllers
{
    //[Authorize]
    [BreezeController]
    public class BreezeController : ApiController
    {
        private EFContextProvider<NgQuizContext> _contextProvider;

        public BreezeController()
        {
            _contextProvider = new EFContextProvider<NgQuizContext>();
        }

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpGet]
        public IQueryable<Phrase> Phrases()
        {
            return _contextProvider.Context.Phrases;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }
    }
}
