using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;

namespace AngularQuiz.Core.AnswerCheck
{
    public interface ICheckAnswerStrategy<TQuestion> where TQuestion : IQuestion
    {
        CheckAnswerResult Check(QuestionUserAnswer userAnswer, TQuestion question);
    }
}
