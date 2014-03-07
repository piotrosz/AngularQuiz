using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class CheckAnswerCategoryQuestionStrategy : ICheckAnswerStrategy<CategoryQuestion>
    {
        public CheckAnswerResult Check(QuestionUserAnswer userAnswer, CategoryQuestion question)
        {
            throw new NotImplementedException();
        }
    }
}
