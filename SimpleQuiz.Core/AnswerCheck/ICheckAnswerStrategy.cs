using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;

namespace SimpleQuiz.Core.AnswerCheck
{
    public interface ICheckAnswerStrategy<TQuestion> where TQuestion : Question
    {
        CheckAnswerResult Check(QuestionUserAnswer userAnswer, TQuestion question);
    }
}
