using System;
using System.Collections.Generic;

namespace SimpleQuiz.Tests
{
    public class QuizCollectionFakeImporter : IQuizCollectionImporter
    {
        public IEnumerable<Quiz> Import()
        {
            var result = new QuizCollection()
            {
                new Quiz()
                {
                    new TextQuestion
                    {
                        Content = "¿Que tal?",
                        CorrectAnswers = new List<string>() { "Bien" }
                    },
                    new TextQuestion
                    {
                        Content = "Question 2",
                        CorrectAnswers = new List<string>() { "Possible answer 1", "Possible answer 2" }
                    },
                    new OptionQuestion
                    {
                        Content = "Po wodzie pływa kaczka się nazywa",
                        CorrectAnswers = new List<string>() { "a" },
                        Options = new List<Option>()
                        {
                            new Option { Id = "a", Name = "Kaczka" },
                            new Option { Id = "b", Name = "Rak" },
                            new Option { Id = "c", Name = "Ryba" }
                        }
                    }
                },
                new Quiz()
                {
                    new TextQuestion
                    {
                        Content = "Question 4",
                        CorrectAnswers = new List<string>() { "Answer" }
                    },
                    new OptionQuestion
                    {
                        Content = "Question 5",
                        CorrectAnswers = new List<string> { "a", "c" },
                        Options = new List<Option>()
                        {
                            new Option { Id = "a", Name = "10" },
                            new Option { Id = "b", Name = "20" },
                            new Option { Id = "c", Name = "30" }
                        }
                    },
                    new AntomineQuestion
                    {
                        Content = "Bien",
                        CorrectAnswers = new List<string>() { "Mal" }
                    }
                }
            };
            
            return result;
        }
    }
}
