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
    public class CheckAnswerSortQuestionStrategyFacts
    {
        private CheckAnswerSortQuestionStrategy _target;

        public CheckAnswerSortQuestionStrategyFacts()
        {
            _target = new CheckAnswerSortQuestionStrategy();
        }

        [Fact]
        public void should_check_correct_answer()
        {
            // Arrange
            var question = StubSortQuestions.SortQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id);
            userAnswer.Answers.Add("A");
            userAnswer.Answers.Add("B");
            userAnswer.Answers.Add("C");

            // Act
            var result = _target.Check(userAnswer, question);

            // Arrange
            Assert.True(result.IsCorrect);
            Assert.Equal(3, result.CorrectAswersIds.Count);
        }

        [Fact]
        public void should_check_incorrect_answer()
        {
            // Arrange
            var question = StubSortQuestions.SortQuestion;
            var userAnswer = new QuestionUserAnswer(question.Id);
            userAnswer.Answers.Add("C");
            userAnswer.Answers.Add("A");
            userAnswer.Answers.Add("B");

            // Act
            var result = _target.Check(userAnswer, question);

            // Arrange
            Assert.False(result.IsCorrect);
            Assert.Empty(result.CorrectAswersIds);
        }
    }
}
