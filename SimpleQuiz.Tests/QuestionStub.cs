using System;

namespace SimpleQuiz.Tests
{
    public class QuestionStub
    {
        public static TextQuestion TextQuestion
        {
            get { return new TextQuestion("Po wodzie pływa kaczka się nazywa", "kaczka"); }
        }
    }
}
