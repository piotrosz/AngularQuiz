using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngularQuiz.Extensions
{
    public static class QuestionExtrensions
    {
        public static string GetFirstOptionInFirstQuestion(this OpenQuestion question)
        {
            return question.Answers.First().CorrectAnswerOptions.First().Content;
        }
    }
}
