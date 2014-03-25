using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class QuizAnswersChecker : IQuizAnswerChecker
    {
        private QuestionCheckStrategies _answerStrategies;

        private QuizUserAnswers _userAnswers;

        private CheckQuizAnswersResult _checkQuizAnswersResult;
        private Quiz _quiz;
        
        public QuizAnswersChecker(QuestionCheckStrategies answerStrategies)
        {
            _answerStrategies = answerStrategies;
        }

        public CheckQuizAnswersResult Check(Quiz quiz, QuizUserAnswers userAnswers)
        {
            _checkQuizAnswersResult = new CheckQuizAnswersResult(quiz);
            _userAnswers = userAnswers;

            CheckQuestionGroup<OpenQuestion>(quiz.OpenQuestions, _answerStrategies.OpenQuestionStrategy, _userAnswers.OpenQuestionsAnswers);
            CheckQuestionGroup<SortQuestion>(quiz.SortQuestions, _answerStrategies.SortQuestionStrategy, _userAnswers.SortQuestionsAnswers);
            CheckQuestionGroup<TestQuestion>(quiz.TestQuestions, _answerStrategies.TestQuestionStrategy, _userAnswers.TestQuestionsAnswers);
            CheckQuestionGroup<CategoryQuestion>(quiz.CategoryQuestions, _answerStrategies.CategoryQuestionStrategy, _userAnswers.CategoryQuestionsAnswers);

            return _checkQuizAnswersResult;
        }

        private void CheckQuestionGroup<TQuestion>(ICollection<TQuestion> questions, ICheckAnswerStrategy<TQuestion> checkAnswerStrategy, List<QuestionUserAnswer> userAnswers)
            where TQuestion : IQuestion
        {
            foreach (var question in questions)
            {
                var userAnswer = userAnswers.SingleOrDefault(a => a.QuestionId == question.Id);

                if (userAnswer == null)
                {
                    throw new ApplicationException("UserAnswer not found");
                }

                CheckAnswerResult checkAnswerResult = checkAnswerStrategy.Check(userAnswer, question);
                _checkQuizAnswersResult.AnswersResults.Add(checkAnswerResult);
            }
        }
    }
}
