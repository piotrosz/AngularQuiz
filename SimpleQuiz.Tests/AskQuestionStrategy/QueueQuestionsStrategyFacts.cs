using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimpleQuiz.Tests.AskQuestionStrategy
{
    public class QueueQuestionsStrategyFacts
    {
        public class GetNextQuestionMethod
        {
            [Fact]
            public void FirstQuestionIsOldest()
            {
                // Arrange
                var target = new QueueQuestionsStrategy();
                var quiz = new QuizCollectionFakeImporter().Import().First();
                target.Quiz = quiz;


                // Act
                var result = target.GetNextQuestion();


                // Assert
                Assert.Equal(quiz.First().Content, result.Content);
            }
        }
    }
}
