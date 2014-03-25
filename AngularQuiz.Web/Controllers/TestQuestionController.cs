using AngularQuiz.Core.DAL;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularQuiz.Web.Controllers
{
    public class TestQuestionController : QuizControllerBase<TestQuestion>
    {
        public TestQuestionController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.TestQuestion) { }

        // GET api/TestQuestion/5
        [ResponseType(typeof(TestQuestion))]
        public IHttpActionResult GetTestQuestion(int id)
        {
            return GetEntity(id);
        }

        // PUT api/TestQuestion/5
        public IHttpActionResult PutTestQuestion(int id, TestQuestion question)
        {
            return PutEntity(id, question);
        }

        // POST api/TestQuestion
        [ResponseType(typeof(TestQuestion))]
        public IHttpActionResult PostTestQuestion(TestQuestion question)
        {
            return PostEntity(question);
        }

        // DELETE api/TestQuestion/5
        [ResponseType(typeof(TestQuestion))]
        public IHttpActionResult DeleteTestQuestion(int id)
        {
            return DeleteEntity(id);
        }
    }
}