using Ninject.Modules;
using SimpleQuiz.Core.AnswerCheck;
using SimpleQuiz.Core.DAL;
using SimpleQuiz.Core.Model.Questions;
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

            Bind<ICheckAnswerStrategy<OpenQuestion>>().To<CheckAnswerOpenQuestionStrategy>();
            Bind<ICheckAnswerStrategy<CategoryQuestion>>().To<CheckAnswerCategoryQuestionStrategy>();
            Bind<ICheckAnswerStrategy<TestQuestion>>().To<CheckAnswerTestQuestionStrategy>();
            Bind<ICheckAnswerStrategy<SortQuestion>>().To<CheckAnswerSortQuestionStrategy>();
        }
    }
}
