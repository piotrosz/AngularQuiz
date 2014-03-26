using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularQuiz.Core.Model;
using AngularQuiz.Core.DAL;
using AngularQuiz.Core.AnswerCheck;
using AngularQuiz.Core.Model.Questions;
using AngularQuiz.Web.Infrastructure;

namespace AngularQuiz.Web.Controllers
{
    public class QuizController : QuizControllerBase<Quiz>
    {
        public QuizController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Quiz) {}

        [Route("api/quizesbypackage/{packageId:int:min(0)}")]
        public IEnumerable<Quiz> GetQuizesByPackageId(int packageId)
        {
            return _unitOfWork.Quiz.List().Where(q => q.QuizPackageId == packageId).ToList();
        }

        // GET api/Quiz/5
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult GetQuiz(int id)
        {
            Quiz quiz = _unitOfWork.Quiz.List()
               .Include("OpenQuestions.Answers.CorrectAnswerOptions")
               .SingleOrDefault(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // PUT api/Quiz/5
        public IHttpActionResult PutQuiz(int id, Quiz quiz)
        {
            return PutEntity(id, quiz);
        }

        // POST api/Quiz
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult PostQuiz(Quiz quiz)
        {
            return PostEntity(quiz);
        }

        // DELETE api/Quiz/5
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult DeleteQuiz(int id)
        {
            return DeleteEntity(id);
        }
    }
}