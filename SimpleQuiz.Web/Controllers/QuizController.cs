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

namespace SimpleQuiz.Web.Controllers
{
    public class QuizController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        private IQuizAnswerChecker _answerChecker;

        public QuizController(IUnitOfWork unitOfWork, IQuizAnswerChecker answerChecker)
        {
            _unitOfWork = unitOfWork;
            _answerChecker = answerChecker;
        }

        // GET api/Quiz
        public IQueryable<Quiz> GetQuizes()
        {
            return _unitOfWork.Quiz.List();
        }

        // GET api/Quiz/5
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult GetQuiz(int id)
        {
            Quiz quiz = _unitOfWork.Quiz.List()
                .Include("Questions")
                .Include("Questions.CorrectAnswers")
                .Include("Questions.CorrectAnswers.CorrectAnswerOptions")
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Quiz.Attach(quiz);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Quiz
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult PostQuiz(Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Quiz.Insert(quiz);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = quiz.Id }, quiz);
        }


        public IHttpActionResult CheckAnswers(QuizUserAnswers userAnswers)
        {
            var quiz = _unitOfWork.Quiz.List().SingleOrDefault(q => q.Id == userAnswers.QuizId);

            if(quiz == null)
            {
                return NotFound();
            }

            CheckQuizAnswersResult result = _answerChecker.Check(quiz, userAnswers);

            return Ok(result);
        }

        // DELETE api/Quiz/5
        [ResponseType(typeof(Quiz))]
        public IHttpActionResult DeleteQuiz(int id)
        {
            Quiz quiz = _unitOfWork.Quiz.List().SingleOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            _unitOfWork.Quiz.Delete(quiz);
            _unitOfWork.Save();

            return Ok(quiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizExists(int id)
        {
            return _unitOfWork.Quiz.List().Any(e => e.Id == id);
        }
    }
}