using SimpleQuiz.CheckAnswerStrategy;
using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public class QuizAnswersChecker : IQuizAnswerChecker
    {
        private ICheckAnswerStrategy _checkAnswerStrategy;

        public QuizAnswersChecker(ICheckAnswerStrategy checkAnswerStrategy)
        {
            this._checkAnswerStrategy = checkAnswerStrategy;
        }

        public CheckQuizAnswersResult Check(Quiz quiz, QuizUserAnswers userAnswers)
        {
            var result = new CheckQuizAnswersResult(quiz);

            foreach(var question in quiz.Questions)
            {
                var userAnswer = userAnswers.Answers.SingleOrDefault(a => a.QuestionId == question.Id);

                if(userAnswer == null)
                {
                    throw new ApplicationException("UserAnswer not found");
                }

                CheckAnswerResult checkAnswerResult = _checkAnswerStrategy.Check(userAnswer, question);
                result.AnswersResults.Add(checkAnswerResult);
            }

            return result;
        }
    }
}
