using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Tests
{
    public class QuestionStub
    {
        public static TextQuestion TextQuestion
        {
            get
            {
                return new TextQuestion
                {
                    Content = "Po wodzie pływa kaczka się nazywa",
                    CorrectAnswers = new List<string>() { "kaczka" }
                };
            }
        }
    }
}
