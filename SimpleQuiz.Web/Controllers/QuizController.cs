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
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.DAL;
using SimpleQuiz.Core.AnswerCheck;
using SimpleQuiz.Core.Model.Questions;

namespace SimpleQuiz.Web.Controllers
{
    public class QuizController : QuizControllerBase<Quiz>
    {
        public QuizController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Quiz) {}

        //private IQuizAnswerChecker _answerChecker;

        //public QuizController(IQuizAnswerChecker answerChecker)
        //{
        //    _answerChecker = answerChecker;
        //}

        [Route("api/quizesbypackage/{packageId:int:min(1)}")]
        public IEnumerable<Quiz> GetQuizesByPackageId(int packageId)
        {
            return _unitOfWork.Quiz.List().Where(q => q.QuizPackageId == packageId).ToList();
        }

        // GET api/Quiz/5
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult GetQuiz(int id)
        {
            Quiz quiz = _unitOfWork.Quiz.List()
                .Include("OpenQuestions")
                .Include("OpenQuestions.CorrectAnswers")
                .Include("OpenQuestions.CorrectAnswers.CorrectAnswerOptions")
                .Include("TestQuestions")
                .Include("TestQuestions.Options")
                .Include("CategoryQuestions")
                .Include("CategoryQuestions.Options")
                .Include("SortQuestions")
                .Include("SortQuestions.Options")
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

        //[Route("api/quizcheckanswers")]
        //public IHttpActionResult CheckAnswers(QuizUserAnswers userAnswers)
        //{
        //    var quiz = _unitOfWork.Quiz.List().SingleOrDefault(q => q.Id == userAnswers.QuizId);

        //    if(quiz == null)
        //    {
        //        return NotFound();
        //    }

        //    CheckQuizAnswersResult result = _answerChecker.Check(quiz, userAnswers);

        //    return Ok(result);
        //}

        // DELETE api/Quiz/5
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult DeleteQuiz(int id)
        {
            return DeleteEntity(id);
        }
    }
}