using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimpleQuiz.Tests.Question
{
    public class TextQuestionFacts
    {
        public class IsAnswerCorrectMethod
        {
            [Fact]
            void SingleCorrectAnswerIsCorrect()
            {
                // Arrange 
                var target = new TextQuestion("Po wodzie pływa kaczka się nazywa", "Kaczka");

                
                // Act 
                var result = target.IsAnswerCorrect("kaczka");


                // Assert
                Assert.Equal(true, result);
            }

            [Fact]
            void MultipleCorrectAnswersAreCorrect()
            {
                // Arrange 
                var target = new TextQuestion();
                target.Content = "Po wodzie pływają kaczka i żółw się nazywają";
                target.CorrectAnswers = new List<string>() { "Kaczka", "Żółw" };


                // Act 
                var result = target.IsAnswerCorrect("żółw, kaczka");


                // Assert
                Assert.Equal(true, result);
            }

            [Fact]
            void MultipleAnswersOneIncorrect()
            {
                // Arrange 
                var target = new TextQuestion();
                target.Content = "Po wodzie pływają kaczka i żółw się nazywają";
                target.CorrectAnswers = new List<string>() { "Kaczka", "Żółw" };


                // Act 
                var result = target.IsAnswerCorrect("żółw, pies");


                // Assert
                Assert.Equal(false, result);
            }

            [Fact]
            void MultipleAnswersCorrectWithSpaces()
            {
                // Arrange 
                var target = new TextQuestion();
                target.Content = "Po wodzie pływają kaczka i żółw się nazywają";
                target.CorrectAnswers = new List<string>() { "Kaczka", "Żółw" };


                // Act 
                var result = target.IsAnswerCorrect("żółw , Kaczka");


                // Assert
                Assert.Equal(true, result);
            }
        }
    }
}
