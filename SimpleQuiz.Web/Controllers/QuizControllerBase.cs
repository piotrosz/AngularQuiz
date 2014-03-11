using SimpleQuiz.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleQuiz.Web.Controllers
{
    public class QuizControllerBase : ApiController
    {
        protected IUnitOfWork _unitOfWork;

        public QuizControllerBase()
        {

        }

        public QuizControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
