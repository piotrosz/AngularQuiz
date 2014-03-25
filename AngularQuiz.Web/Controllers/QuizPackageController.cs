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
using Ninject;
using AngularQuiz.Web.Infrastructure;

namespace AngularQuiz.Web.Controllers
{
    // TODO: Enable Authorize
    //[Authorize(Roles="admin")]
    public class QuizPackageController : QuizControllerBase<QuizPackage>
    {
        public QuizPackageController(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.QuizPackage) {}

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
            return GetEntity(id);
        }

        // PUT api/QuizPackage/5
        public IHttpActionResult PutQuizPackage(int id, QuizPackage quizPackage)
        {
            return PutEntity(id, quizPackage);
        }

        // POST api/QuizPackage
        [ResponseType(typeof(QuizPackage))]
        public IHttpActionResult PostQuizPackage(QuizPackage quizPackage)
        {
            return PostEntity(quizPackage);
        }

        // DELETE api/QuizPackage/5
        [ResponseType(typeof(QuizPackage))]
        public IHttpActionResult DeleteQuizPackage(int id)
        {
            return DeleteEntity(id);
        }  
    }
}