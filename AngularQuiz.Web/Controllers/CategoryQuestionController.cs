using AngularQuiz.Core.DAL;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularQuiz.Web.Controllers
{
    public class CategoryQuestionController : QuizControllerBase<CategoryQuestion>
    {
        public CategoryQuestionController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CategoryQuestion) { }

        // GET api/CategoryQuestion/5
        [ResponseType(typeof(CategoryQuestion))]
        public IHttpActionResult GetCategoryQuestion(int id)
        {
            return GetEntity(id);
        }

        // PUT api/CategoryQuestion/5
        public IHttpActionResult PutCategoryQuestion(int id, CategoryQuestion question)
        {
            return PutEntity(id, question);
        }

        // POST api/CategoryQuestion
        [ResponseType(typeof(CategoryQuestion))]
        public IHttpActionResult PostCategoryQuestion(CategoryQuestion question)
        {
            return PostEntity(question);
        }

        // DELETE api/CategoryQuestion/5
        [ResponseType(typeof(CategoryQuestion))]
        public IHttpActionResult DeleteCategoryQuestion(int id)
        {
            return DeleteEntity(id);
        }
    }
}