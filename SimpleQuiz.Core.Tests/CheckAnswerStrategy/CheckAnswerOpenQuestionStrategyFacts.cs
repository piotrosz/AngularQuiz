using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleQuiz.Extensions;
using SimpleQuiz.Core.Tests.Stubs;
using Xunit;
using SimpleQuiz.Core.AnswerCheck;
using SimpleQuiz.Core.Model.Questions;

namespace SimpleQuiz.Core.Tests.CheckAnswerStrategy
{
    public class CheckAnswerOpenQuestionStrategyFacts
    {
        private CheckAnswerOpenQuestionStrategy _target;

        public CheckAnswerOpenQuestionStrategyFacts()
        {
            _target = new CheckAnswerOpenQuestionStrategy();
        }

        [Fact]
        public void should_check_correct_answer_for_single_answer_single_option_question()
        {
            // Arrange
            var question = StubOpenQuestions.SingleAnswerSingleOptionQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id, question.GetFirstOptionInFirstQuestion());
            
            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Equal(1, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answer_for_single_answer_single_option_question()
        {
            // Arrange
            var question = StubOpenQuestions.SingleAnswerSingleOptionQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id, "This is wrong answer");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Empty(result.CorrectAswersIds);
        }

        [Fact]
        public void should_check_correct_answers_for_multi_answers_single_option()
        {
            // Arrange
            var question = StubOpenQuestions.ThreeAnswersSingleOptionQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id);
            userAnswer.Answers.Add("red");
            userAnswer.Answers.Add("black");
            userAnswer.Answers.Add("blue");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Equal(3, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answers_order_for_multi_answers_single_option()
        {
            // Arrange
            var question = StubOpenQuestions.ThreeAnswersSingleOptionQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id);
            userAnswer.Answers.Add("black"); // Wrong order
            userAnswer.Answers.Add("red");
            userAnswer.Answers.Add("blue");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Equal(1, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_correct_answer_for_single_answer_multi_option_question()
        {
            // Arrange
            var question = StubOpenQuestions.SingleAnswerThreeOptionsQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id, question.GetFirstOptionInFirstQuestion());

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.True(result.IsCorrect);
            Assert.Equal(1, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answer_for_single_answer_multi_option_question()
        {
            // Arrange
            var question = StubOpenQuestions.SingleAnswerThreeOptionsQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id, "baba");

            // Act
            var result = _target.Check(userAnswer, question);

            // Assert
            Assert.False(result.IsCorrect);
            Assert.Empty(result.CorrectAswersIds);
        }
    }
}
