using System;
using System.Linq;
using System.Collections.Generic;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class CheckAnswerResult
    {
        public IQuestion Question { get; private set; }

        public CheckAnswerResult(IQuestion question)
        {
            CorrectAswersIds = new List<int>();
            Question = question;
        }

        public bool IsCorrect { get; set; }

        public List<int> CorrectAswersIds { get; set; }
    }
}
