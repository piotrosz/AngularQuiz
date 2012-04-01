using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimpleQuiz.Tests.CheckAnswerStrategy
{
    public class CheckAnswerYNStrategyFacts
    {
        public class CheckMethod
        {
            [Fact]
            public void ChecksCorrectAnswer()
            {
                // Arrange
                var question = QuestionStub.TextQuestion;
                var target = new CheckAnswerYNStrategy();


                // Act 
                var result = target.Check("Y", question);


                // Assert
                Assert.Equal(true, result.IsCorrect);
            }

            [Fact]
            public void ChecksIncorrectAnswer()
            {
                // Arrange
                var question = QuestionStub.TextQuestion;
                var target = new CheckAnswerYNStrategy();


                // Act 
                var result = target.Check("N", question);


                // Assert
                Assert.Equal(false, result.IsCorrect);
            }
        }
    }
}
