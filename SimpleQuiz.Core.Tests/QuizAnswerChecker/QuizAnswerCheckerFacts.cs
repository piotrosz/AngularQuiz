using SimpleQuiz.Core.AnswerCheck;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using SimpleQuiz.Core.Tests.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleQuiz.Core.Tests.QuizAnswerChecker
{
    public class QuizAnswerCheckerFacts
    {
        private Quiz _quiz;
        private QuizAnswersChecker _target;

        public QuizAnswerCheckerFacts()
        {
            _quiz = StubQuizes.Quiz;
            _target = new QuizAnswersChecker(_quiz, new QuestionCheckStrategies
                {
                    CategoryQuestionStrategy = new CheckAnswerCategoryQuestionStrategy(),
                    OpenQuestionStrategy = new CheckAnswerOpenQuestionStrategy(),
                    TestQuestionStrategy = new CheckAnswerTestQuestionStrategy(),
                    SortQuestionStrategy = new CheckAnswerSortQuestionStrategy()
                });
        }

        [Fact]
        public void should_check_correct_answers()
        {
            // Arrange
            var answers = new QuizUserAnswers(_quiz.Id);
            answers.Answers.Add(new QuestionUserAnswer(_quiz.OpenQuestions.ElementAt(0).Id)
                {
                    Answers = new List<string> { "Kaczka" }
                });

            // TODO

            // Act
            var result = _target.Check(answers);

            // Assert
            Assert.True(result.CorrectAnswersCount == answers.Answers.Count);
        }
    }
}
