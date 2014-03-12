using SimpleQuiz.Core.DAL;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SimpleQuiz.Web.Controllers
{
    public class SortQuestionController : QuizControllerBase<SortQuestion>
    {
        public SortQuestionController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.SortQuestion) { }

        // GET api/SortQuestion/5
        [ResponseType(typeof(SortQuestion))]
        public IHttpActionResult GetSortQuestion(int id)
        {
            return GetEntity(id);
        }

        // PUT api/SortQuestion/5
        public IHttpActionResult PutSortQuestion(int id, SortQuestion question)
        {
            return PutEntity(id, question);
        }

        // POST api/SortQuestion
        [ResponseType(typeof(SortQuestion))]
        public IHttpActionResult PostSortQuestion(SortQuestion question)
        {
            return PostEntity(question);
        }

        // DELETE api/SortQuestion/5
        [ResponseType(typeof(SortQuestion))]
        public IHttpActionResult DeleteSortQuestion(int id)
        {
            return DeleteEntity(id);
        }
    }
}