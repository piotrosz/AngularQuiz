using SimpleQuiz.CheckAnswerStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleQuiz.Extensions;
using SimpleQuiz.Core.Tests.Stubs;
using SimpleQuiz.Core.Model;
using Xunit;

namespace SimpleQuiz.Core.Tests.CheckAnswerStrategy
{
    public class AnswerExactStrategyFacts
    {
        [Fact]
        public void should_check_correct_answer_for_single_answer_single_option_question()
        {
            // Arrange
            var target = new AnswerExactStrategy();
            var question = StubQuestions.SingleAnswerSingleOptionQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id, question.GetFirstOptionInFirstQuestion());
            
            // Act
            var result = target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Empty(result.IncorrectAnswersIds);
            Assert.Equal(1, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answer_for_single_answer_single_option_question()
        {
            // Arrange
            var target = new AnswerExactStrategy();
            var question = StubQuestions.SingleAnswerSingleOptionQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id, "This is wrong answer");

            // Act
            var result = target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Equal(1, result.IncorrectAnswersIds.Count);
            Assert.Empty(result.CorrectAswersIds);
        }

        // TODO: Write more tests
    }
}
