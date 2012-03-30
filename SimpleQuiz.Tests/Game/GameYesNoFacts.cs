using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace SimpleQuiz.Tests.Game
{
    public class GameYesNoFacts
    {
        public class Constructor
        {
            [Fact]
            public void CorrectlyInitialized()
            {
                // Arrange
                var target = new GameYesNo();
                var quiz = new QuizCollectionFakeImporter().Import().First();
                target.Quiz = quiz;

                // Act


                // Assert
                Assert.Equal(false, target.GameResult.IsFinished);
                Assert.Equal(quiz.Count, target.GameResult.MaxPoints);
                Assert.Equal(0, target.GameResult.Points);
            }
        }

        public class GetNextQuestionMethod
        {
            [Fact]
            public void ReturnsNotNullWhenGameStarted()
            {
                // Arrange
                var target = new GameYesNo();
                target.Quiz = new QuizCollectionFakeImporter().Import().First();


                // Act
                var result = target.GetNextQuestion();


                // Assert
                Assert.NotNull(result);
            }

            [Fact]
            public void ReturnsNullWhenGameFinished()
            {
                // Arrange
                var target = new GameYesNo();
                Quiz quiz = new QuizCollectionFakeImporter().Import().First();
                target.Quiz = quiz;


                // Act
                Question result = null;

                for(int i = 0; i < quiz.Count; i++)
                    result = target.GetNextQuestion();

                result = target.GetNextQuestion();


                // Assert
                Assert.Null(result);
            }
        }

        public class CheckAnswerMethod
        {
            [Fact]
            public void PointsIncrementedAfterCorrectAnswer()
            {
                // Arrange
                var target = new GameYesNo();
                target.Quiz = new QuizCollectionFakeImporter().Import().First();


                // Act
                var question = target.GetNextQuestion();
                var result = target.CheckAnswer("Y"); // Y is always correct answer


                // Assert
                Assert.Equal(true, result.IsCorrect);
                Assert.Equal(1, target.GameResult.Points);
            }

            [Fact]
            public void PointsNotIncrementedAfterWrongAnswer()
            {
                // Arrange
                var target = new GameYesNo();
                target.Quiz = new QuizCollectionFakeImporter().Import().First();


                // Act
                var question = target.GetNextQuestion();
                var result = target.CheckAnswer("This is very wrong answer");


                // Assert
                Assert.Equal(false, result.IsCorrect);
                Assert.Equal(0, target.GameResult.Points);
                Assert.Equal(false, target.GameResult.IsFinished);
            }
        }

        
    }
}
