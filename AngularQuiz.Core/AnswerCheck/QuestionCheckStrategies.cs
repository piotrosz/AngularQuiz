using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.AnswerCheck
{
    public class QuestionCheckStrategies
    {
        public ICheckAnswerStrategy<OpenQuestion> OpenQuestionStrategy { get; set; }
        public ICheckAnswerStrategy<CategoryQuestion> CategoryQuestionStrategy { get; set; }
        public ICheckAnswerStrategy<TestQuestion> TestQuestionStrategy { get; set; }
        public ICheckAnswerStrategy<SortQuestion> SortQuestionStrategy { get; set; }
    }
}
