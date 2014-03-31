using AngularQuiz.Core.DAL;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularQuiz.Web.Controllers
{
    public class TestQuestionOptionController : QuizControllerBase<TestQuestionOption>
    {
        public TestQuestionOptionController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.TestQuestionOption) {}

        // PUT api/TestQuestionOption/5
        public IHttpActionResult PutTestQuestionOption(int id, TestQuestionOption option)
        {
            return PutEntity(id, option);
        }

        // POST api/TestQuestionOption
        [ResponseType(typeof(TestQuestionOption))]
        public IHttpActionResult PostTestQuestionOption(TestQuestionOption option)
        {
            return PostEntity(option);
        }

        // DELETE api/TestQuestionOption/5
        [ResponseType(typeof(TestQuestionOption))]
        public IHttpActionResult DeleteTestQuestionOption(int id)
        {
            return DeleteEntity(id);
        }
    }
}
