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
        
        public QuizAnswersChecker(Quiz quiz, QuestionCheckStrategies answerStrategies)
        {
            _quiz = quiz;
            _checkQuizAnswersResult = new CheckQuizAnswersResult(_quiz);
            _answerStrategies = answerStrategies;
        }

        public CheckQuizAnswersResult Check(QuizUserAnswers userAnswers)
        {
            _userAnswers = userAnswers;

            CheckQuestionGroup<OpenQuestion>(_quiz.OpenQuestions, _answerStrategies.OpenQuestionStrategy);
            CheckQuestionGroup<SortQuestion>(_quiz.SortQuestions, _answerStrategies.SortQuestionStrategy);
            CheckQuestionGroup<TestQuestion>(_quiz.TestQuestions, _answerStrategies.TestQuestionStrategy);
            CheckQuestionGroup<CategoryQuestion>(_quiz.CategoryQuestions, _answerStrategies.CategoryQuestionStrategy);

            return _checkQuizAnswersResult;
        }

        private void CheckQuestionGroup<TQuestion>(ICollection<TQuestion> questions, ICheckAnswerStrategy<TQuestion> checkAnswerStrategy)
            where TQuestion : Question
        {
            foreach (var question in questions)
            {
                var userAnswer = _userAnswers.Answers.SingleOrDefault(a => a.QuestionId == question.Id);

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
