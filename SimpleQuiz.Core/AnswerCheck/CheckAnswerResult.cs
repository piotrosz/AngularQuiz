using System;
using System.Linq;
using System.Collections.Generic;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class CheckAnswerResult
    {
        public Question Question { get; private set; }

        public CheckAnswerResult(Question question)
        {
            CorrectAswersIds = new List<int>();
            Question = question;
        }

        public bool IsCorrect { get; set; }

        public List<int> CorrectAswersIds { get; set; }
    }
}
