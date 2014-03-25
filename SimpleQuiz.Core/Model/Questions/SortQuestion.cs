using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Model.Questions
{
    public class SortQuestion : Question<SortQuestionOption>
    {
        public override ICollection<SortQuestionOption> Answers { get; set; }
    }
}
