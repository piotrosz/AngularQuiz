using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.AnswerCheck
{
    public interface IQuizAnswerChecker
    {
        CheckQuizAnswersResult Check(QuizUserAnswers userAnswers);
    }
}
