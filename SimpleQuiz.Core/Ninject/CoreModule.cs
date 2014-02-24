using Ninject.Modules;
using SimpleQuiz.CheckAnswerStrategy;
using SimpleQuiz.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Ninject
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IQuizAnswerChecker>().To<QuizAnswersChecker>();
            Bind<ICheckAnswerStrategy>().To<AnswerExactStrategy>();
        }
    }
}
