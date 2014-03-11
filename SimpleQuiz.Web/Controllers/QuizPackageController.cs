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
using SimpleQuiz.Web.Infrastructure;

namespace SimpleQuiz.Web.Controllers
{
    // TODO: Enable Authorize
    //[Authorize(Roles="admin")]
    public class QuizPackageController : QuizControllerBase
    {
        public QuizPackageController(IUnitOfWork unitOfWork) : base(unitOfWork) {}

        // GET api/QuizPackage
        public PagedResults<QuizPackage> GetQuizPackages(int pageSize, int offset, string searchPhrase = null)
        {
            IEnumerable<QuizPackage> list = _unitOfWork.QuizPackage.List();
            int totalCount;

            if(!string.IsNullOrWhiteSpace(searchPhrase))
            {
                list = list.Where(p => p.Name.ToLower().Contains(searchPhrase.ToLower()));
                totalCount = _unitOfWork.QuizPackage.Count(p => p.Name.ToLower().Contains(searchPhrase.ToLower()));
            }
            else
            {
                totalCount = _unitOfWork.QuizPackage.Count();
            }

            list = list.OrderBy(p => p.Name)
                .Skip(offset)
                .Take(pageSize)
                .ToList();

            return new PagedResults<QuizPackage>()
            {
                List = list,
                TotalCount = totalCount
            };
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
            QuizPackage quizpackage = _unitOfWork.QuizPackage.List()
                .SingleOrDefault(p => p.Id == id);

            if (quizpackage == null)
            {
                return NotFound();
            }

            _unitOfWork.QuizPackage.Delete(quizpackage);
            _unitOfWork.Save();

            return Ok(quizpackage);
        }

        private bool QuizPackageExists(int id)
        {
            return _unitOfWork.QuizPackage.List().Any(e => e.Id == id);
        }
    }
}