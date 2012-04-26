using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimpleQuiz.Tests.Question
{
    public class OptionQuestionFacts
    {
        public class IsAnswerCorrectMethod
        {
            [Fact]
            void SingleOptionCorrectAnswer()
            {
                // Arrange
                var target = new OptionQuestion
                {
                    Content = "Question text",
                    CorrectAnswers = new List<string>() { "A" },
                    Options = new List<Option>()
                    {
                        new Option { Id = "A", Name = "Option A (Correct)" },
                        new Option { Id = "B", Name = "Option B (Incorrect)" }
                    }
                };


                // Act
                bool result = target.IsAnswerCorrect("A");


                // Assert
                Assert.True(result);
            }

            [Fact]
            void SingleOptionInCorrectAnswer()
            {
                // Arrange
                var target = new OptionQuestion
                {
                    Content = "Question text",
                    CorrectAnswers = new List<string>() { "2" },
                    Options = new List<Option>()
                    {
                        new Option { Id = "1", Name = "Option 1 (Incorrect)" },
                        new Option { Id = "2", Name = "Option 2 (Correct)" }
                    }
                };


                // Act
                bool result = target.IsAnswerCorrect("1");


                // Assert
                Assert.False(result);
            }

            [Fact]
            void MultipleOptionsCorrectAnswer()
            {
                // Arrange
                var target = new OptionQuestion
                {
                    Content = "Question text",
                    CorrectAnswers = new List<string>() { "A", "B" },
                    Options = new List<Option>()
                    {
                        new Option { Id = "A", Name = "Option 1 (Correct)" },
                        new Option { Id = "B", Name = "Option 2 (Correct)" },
                        new Option { Id = "C", Name = "Option 2 (Incorrect)" }
                    }
                };


                // Act
                bool result = target.IsAnswerCorrect("A,B");


                // Assert
                Assert.True(result);
            }

            [Fact]
            void MultipleOptionsIncorrectAnswer()
            {
                // Arrange
                var target = new OptionQuestion
                {
                    Content = "Question text",
                    CorrectAnswers = new List<string>() { "A", "B" },
                    Options = new List<Option>()
                    {
                        new Option { Id = "A", Name = "Option 1 (Correct)" },
                        new Option { Id = "B", Name = "Option 2 (Correct)" },
                        new Option { Id = "C", Name = "Option 2 (Incorrect)" }
                    }
                };


                // Act
                bool result = target.IsAnswerCorrect("A,C");


                // Assert
                Assert.False(result);
            }
        }
    }
}
