using SimpleQuiz.Core.DAL;
using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SimpleQuiz.Web.Controllers
{
    public class QuizControllerBase<TEntity> : ApiController where TEntity : Entity
    {
        protected IUnitOfWork _unitOfWork;
        protected IGenericRepository<TEntity> _repository;

        public QuizControllerBase(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected IHttpActionResult GetEntity(int id)
        {
            TEntity entity = _repository.List().SingleOrDefault(e => e.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        protected IHttpActionResult PutEntity(int id, TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            _repository.Attach(entity);

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
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

        protected IHttpActionResult PostEntity(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Insert(entity);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        protected IHttpActionResult DeleteEntity(int id)
        {
            TEntity entity = _repository.List().SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _repository.Delete(entity);
            _unitOfWork.Save();

            return Ok(entity);
        }

        private bool EntityExists(int id)
        {
            return _repository.List().Any(e => e.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
