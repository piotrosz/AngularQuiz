using SimpleQuiz.Core.Model;
using System;

namespace SimpleQuiz.CheckAnswerStrategy
{
    public interface ICheckAnswerStrategy
    {
        CheckAnswerResult Check(QuestionUserAnswer userAnswer, Question question);
    }
}
