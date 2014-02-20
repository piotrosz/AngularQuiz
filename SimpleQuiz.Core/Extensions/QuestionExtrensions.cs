using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Extensions
{
    public static class QuestionExtrensions
    {
        public static string GetFirstOptionInFirstQuestion(this Question question)
        {
            return question.CorrectAnswers.First().CorrectAnswerOptions.First().Content;
        }
    }
}
