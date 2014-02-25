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
using Ninject;

namespace SimpleQuiz.Web.Controllers
{
    public class QuizPackageController : ApiController
    {
        protected IUnitOfWork _unitOfWork;

        public QuizPackageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/QuizPackage
        public IQueryable<QuizPackage> GetQuizPackages()
        {
            return _unitOfWork.QuizPackage.List();
        }

        // GET api/QuizPackage/5
        [ResponseType(typeof(QuizPackage))]
        public IHttpActionResult GetQuizPackage(int id)
        {
            QuizPackage quizpackage = _unitOfWork.QuizPackage.List().SingleOrDefault(p => p.Id == id);
            if (quizpackage == null)
            {
                return NotFound();
            }

            return Ok(quizpackage);
        }

        // PUT api/QuizPackage/5
        public IHttpActionResult PutQuizPackage(int id, QuizPackage quizpackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quizpackage.Id)
            {
                return BadRequest();
            }

            _unitOfWork.QuizPackage.Attach(quizpackage);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizPackageExists(id))
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

        // POST api/QuizPackage
        [ResponseType(typeof(QuizPackage))]
        public IHttpActionResult PostQuizPackage(QuizPackage quizpackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.QuizPackage.Insert(quizpackage);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = quizpackage.Id }, quizpackage);
        }

        // DELETE api/QuizPackage/5
        [ResponseType(typeof(QuizPackage))]
        public IHttpActionResult DeleteQuizPackage(int id)
        {
            QuizPackage quizpackage = _unitOfWork.QuizPackage.List().SingleOrDefault(p => p.Id == id);
            if (quizpackage == null)
            {
                return NotFound();
            }

            _unitOfWork.QuizPackage.Delete(quizpackage);
            _unitOfWork.Save();

            return Ok(quizpackage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizPackageExists(int id)
        {
            return _unitOfWork.QuizPackage.List().Any(e => e.Id == id);
        }
    }
}