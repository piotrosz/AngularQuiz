using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Tests.Stubs
{
    internal static class StubQuestions
    {
        public static Question SingleAnswerSingleOptionQuestion
        {
            get { return new Question("Po wodzie pływa kaczka się nazywa?", "kaczka"); }
        }

        public static Question SingleAnswerTwoOptionsQuestion
        {
            get { return new Question("What is one of my favourite colours?", "red", "black", "blue"); }
        }

        public static Question MultiAnswersSingleOptionQuestion
        {
            get
            {
                var question = new Question
                {
                    Content = "What are my 3 favourite colours?",
                    CorrectAnswers = new List<QuestionCorrectAnswer>
                    {
                        new QuestionCorrectAnswer("red"),
                        new QuestionCorrectAnswer("black"),
                        new QuestionCorrectAnswer("blue")
                    }
                };

                return question;
            }
        }

        public static Question MultiAnswersMultiOptionsQuestion
        {
            get
            {
                var question = new Question
                {
                    Content = "What are my 3 favourite colours?",
                    CorrectAnswers = new List<QuestionCorrectAnswer>
                    {
                        new QuestionCorrectAnswer("red", "rojo", "czerwony"),
                        new QuestionCorrectAnswer("black", "negro", "czarny"),
                        new QuestionCorrectAnswer("blue", "azul", "niebieski")
                    }
                };

                return question;
            }
        }
    }
}
