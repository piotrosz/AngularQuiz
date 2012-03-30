using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimpleQuiz.Tests.AskQuestionStrategy
{
    public class StackQuestionsStrategyFacts
    {
        public class GetNextQuestionMethod
        {
            [Fact]
            public void FirstQuestionIsNewest()
            {
                // Arrange
                var target = new StackQuestionsStrategy();
                var quiz = new QuizCollectionFakeImporter().Import().First();
                target.Quiz = quiz;


                // Act
                var result = target.GetNextQuestion();


                // Assert
                Assert.Equal(quiz.Last().Content, result.Content);
            }
        }
    }
}
