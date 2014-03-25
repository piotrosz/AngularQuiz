using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.Model.Questions
{
    public class TestQuestion : Question<TestQuestionOption>
    {
        public override QuestionType QuestionType
        {
            get { return QuestionType.Test; }
        }

        public override ICollection<TestQuestionOption> Answers { get; set; }
    }
}
