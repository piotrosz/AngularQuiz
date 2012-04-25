using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimpleQuiz.Tests
{
    public class QuizCollectionTextParserFacts
    {
        public class ParseMethod
        {
            [Fact]
            void CommentsAreIgnored()
            {
                // Arrange
                var lines = new List<string>()
                {
                    "# This is comment",
                    "",
                    "Sample name",
                    "# Another comment",
                    "Question?answer",
                    "#This is another comment"
                };

                var target = new QuizCollectionTextParser();


                // Act
                var result = target.Parse(lines);


                // Assert
                Assert.Equal(1, result.Count());
                Assert.Equal("Sample name", result.ElementAt(0).Name);
                Assert.Equal(1, result.ElementAt(0).Count);
            }

            [Fact]
            void TwoQuizesCorrectlyParsed()
            {
                // Arrange
                var lines = new List<string>()
                {
                    "Name 1",
                    "Option question? a;b;c$0",
                    "Name 2",
                    "Question text? Answer",
                    "Question 3? aa;bb;cc$0;1"
                };

                var target = new QuizCollectionTextParser();


                // Act
                var result = target.Parse(lines);


                // Assert
                Assert.Equal(2, result.Count());
                Assert.Equal(1, result.ElementAt(0).Count);
                Assert.Equal(2, result.ElementAt(1).Count);
                Assert.Equal("0", result.ElementAt(0)[0].CorrectAnswers.First());
                Assert.Equal("Answer", result.ElementAt(1)[0].CorrectAnswers.First());
            }

            [Fact]
            void QuizWithNoQuestionsNotParsed()
            {
                // Arrange
                var lines = new List<string>()
                {
                    "Quiz 1",
                    "Quiz 2"
                };

                var target = new QuizCollectionTextParser();


                // Act
                var result = target.Parse(lines);


                // Assert
                Assert.Equal(0, result.Count());
            }

            [Fact]
            void InvalidQuizNotParsed()
            {
                // Arrange
                var lines = new List<string>()
                {
                    "   ",
                    "23333?dddd",
                    "dddd",
                    "sadsdsdsdsd",
                    ""
                };

                var target = new QuizCollectionTextParser();


                // Act
                var result = target.Parse(lines);


                // Assert
                Assert.Equal(0, result.Count());
            }
        }
    }
}
