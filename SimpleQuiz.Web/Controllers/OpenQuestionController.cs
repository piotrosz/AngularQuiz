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
using SimpleQuiz.Core.Model.Questions;
using SimpleQuiz.Core.DAL;

namespace SimpleQuiz.Web.Controllers
{
    public class OpenQuestionController : QuizControllerBase
    {
        // GET api/OpenQuestion/5
        [ResponseType(typeof(OpenQuestion))]
        public IHttpActionResult GetOpenQuestion(int id)
        {
            OpenQuestion question = _unitOfWork.OpenQuestion.List().SingleOrDefault(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT api/OpenQuestion/5
        public IHttpActionResult PutOpenQuestion(int id, OpenQuestion question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.Id)
            {
                return BadRequest();
            }

            _unitOfWork.OpenQuestion.Attach(question);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpenQuestionExists(id))
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

        // POST api/OpenQuestion
        [ResponseType(typeof(OpenQuestion))]
        public IHttpActionResult PostOpenQuestion(OpenQuestion question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.OpenQuestion.Insert(question);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = question.Id }, question);
        }

        // DELETE api/OpenQuestion/5
        [ResponseType(typeof(OpenQuestion))]
        public IHttpActionResult DeleteOpenQuestion(int id)
        {
            OpenQuestion question = _unitOfWork.OpenQuestion.List().SingleOrDefault(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            _unitOfWork.OpenQuestion.Delete(question);
            _unitOfWork.Save();

            return Ok(question);
        }

        private bool OpenQuestionExists(int id)
        {
            return _unitOfWork.OpenQuestion.List().Any(e => e.Id == id);
        }
    }
}