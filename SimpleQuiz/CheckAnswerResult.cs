using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public class CheckAnswerResult
    {
        public bool IsCorrect { get; set; }
        public IEnumerable<string> CorrectAnswers { get; set; }

        public string CorrectAnswersLine
        {
            get { return string.Join(", ", CorrectAnswers.ToArray()); }
        }
    }
}
