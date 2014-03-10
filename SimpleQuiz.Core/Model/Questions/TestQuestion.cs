using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Model.Questions
{
    public class TestQuestion : Question
    {
        public ICollection<TestQuestionOption> Options { get; set; }
    }
}
