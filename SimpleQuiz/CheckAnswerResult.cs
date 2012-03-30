using System;
using System.Linq;
using System.Collections.Generic;

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
