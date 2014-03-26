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
    [UserDataOnly]
    public class UserQuizController : QuizControllerBase<Quiz>
    {
        private IQuizAnswerChecker _answerChecker;

        public UserQuizController(IQuizAnswerChecker answerChecker, IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Quiz) 
        {
            _answerChecker = answerChecker;
        }

        // GET api/Quiz/5
        [ResponseType(typeof(Quiz))]
        [Route("api/quizforuser/{id:int:min(0)}")]
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

        [Route("api/quizcheckanswers/{id:int:min(0)}")]
        public IHttpActionResult CheckAnswers(int id, QuizUserAnswers userAnswers)
        {
            var quiz = _unitOfWork.Quiz.List().SingleOrDefault(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            CheckQuizAnswersResult result = _answerChecker.Check(quiz, userAnswers);

            return Ok(result);
        }
	}
}