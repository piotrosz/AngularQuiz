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
using AngularQuiz.Core.Model.Questions;
using AngularQuiz.Core.DAL;

namespace AngularQuiz.Web.Controllers
{
    public class OpenQuestionController : QuizControllerBase<OpenQuestion>
    {
        public OpenQuestionController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.OpenQuestion) {}

        // GET api/OpenQuestion/5
        [ResponseType(typeof(OpenQuestion))]
        public IHttpActionResult GetOpenQuestion(int id)
        {
            return GetEntity(id);
        }

        // PUT api/OpenQuestion/5
        public IHttpActionResult PutOpenQuestion(int id, OpenQuestion question)
        {
            return PutEntity(id, question);
        }

        // POST api/OpenQuestion
        [ResponseType(typeof(OpenQuestion))]
        public IHttpActionResult PostOpenQuestion(OpenQuestion question)
        {
            return PostEntity(question);
        }

        // DELETE api/OpenQuestion/5
        [ResponseType(typeof(OpenQuestion))]
        public IHttpActionResult DeleteOpenQuestion(int id)
        {
            return DeleteEntity(id);
        }
    }
}