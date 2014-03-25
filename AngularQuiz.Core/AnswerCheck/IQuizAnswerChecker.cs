using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngularQuiz.Core.AnswerCheck
{
    public interface IQuizAnswerChecker
    {
        CheckQuizAnswersResult Check(Quiz quiz, QuizUserAnswers userAnswers);
    }
}
