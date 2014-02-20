using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public interface IQuizAnswerChecker
    {
        CheckQuizAnswersResult Check(Quiz quiz, QuizUserAnswers userAnswers);
    }
}
