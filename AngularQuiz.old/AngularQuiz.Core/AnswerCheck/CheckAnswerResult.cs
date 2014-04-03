using System;
using System.Linq;
using System.Collections.Generic;
using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;

namespace AngularQuiz.Core.AnswerCheck
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
