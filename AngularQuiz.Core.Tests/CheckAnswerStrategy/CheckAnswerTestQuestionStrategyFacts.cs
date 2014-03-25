using AngularQuiz.Core.AnswerCheck;
using AngularQuiz.Core.Model.Questions;
using AngularQuiz.Core.Tests.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AngularQuiz.Core.Tests.CheckAnswerStrategy
{
    public class CheckAnswerTestQuestionStrategyFacts
    {
        private CheckAnswerTestQuestionStrategy _target;

        public CheckAnswerTestQuestionStrategyFacts()
        {
            _target = new CheckAnswerTestQuestionStrategy();
        }

        [Fact]
        public void should_check_correct_answer_for_single_option()
        {
            // Arrange
            var question = StubTestQuestions.SingleAnswer;
            var userAnswer = new QuestionUserAnswer(question.Id, "A");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Equal(1, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answer_for_single_option()
        {
            // Arrange
            var question = StubTestQuestions.SingleAnswer;
            var userAnswer = new QuestionUserAnswer(question.Id, "B");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Empty(result.CorrectAswersIds);
        }

        [Fact]
        public void should_check_corect_answer_for_three_options()
        {
            // Arrange
            var question = StubTestQuestions.ThreeAnswers;
            var userAnswer = new QuestionUserAnswer(question.Id) { Answers = new List<string> { "B", "A", "C" } };

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Equal(3, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorect_answer_for_three_options()
        {
            // Arrange
            var question = StubTestQuestions.ThreeAnswers;
            var userAnswer = new QuestionUserAnswer(question.Id) { Answers = new List<string> { "B", "A", "D" } };

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Equal(2, result.CorrectAswersIds.Count);
        }
    }
}
