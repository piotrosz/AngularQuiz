using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.Model.Questions
{
    public class CategoryQuestion : Question<CategoryQuestionOption>
    {
        public override QuestionType QuestionType
        {
            get { return QuestionType.Category; }
        }

        public List<string> Categories { get { return Answers.Select(a => a.Category).Distinct().ToList(); } }

        public override ICollection<CategoryQuestionOption> Answers { get; set; }
    }
}
