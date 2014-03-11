using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Extensions
{
    public static class QuestionExtrensions
    {
        public static string GetFirstOptionInFirstQuestion(this OpenQuestion question)
        {
            return question.CorrectAnswers.First().CorrectAnswerOptions.First().Content;
        }
    }
}
