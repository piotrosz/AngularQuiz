using SimpleQuiz.Core.AnswerCheck;
using SimpleQuiz.Core.Model.Questions;
using SimpleQuiz.Core.Tests.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleQuiz.Core.Tests.CheckAnswerStrategy
{
    public class CheckAnswerCategoryQuestionStrategyFacts
    {
        private CheckAnswerCategoryQuestionStrategy _target;

        public CheckAnswerCategoryQuestionStrategyFacts()
        {
            _target = new CheckAnswerCategoryQuestionStrategy();
        }

        [Fact]
        public void should_check_correct_answer()
        {
            // Arrange
            var question = StubCategoryQuestions.CategoryQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id);
            userAnswer.Answers.Add("Alphabet");
            userAnswer.Answers.Add("Alphabet");
            userAnswer.Answers.Add("Number");
            userAnswer.Answers.Add("Bird");
            userAnswer.Answers.Add("Bird");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Equal(5, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answer()
        {
            // Arrange
            var question = StubCategoryQuestions.CategoryQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id);
            userAnswer.Answers.Add("Alphabet");
            userAnswer.Answers.Add("Bird");
            userAnswer.Answers.Add("Number");
            userAnswer.Answers.Add("Alphabet");
            userAnswer.Answers.Add("Bird");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Equal(3, result.CorrectAswersIds.Count);
        }
    }
}
