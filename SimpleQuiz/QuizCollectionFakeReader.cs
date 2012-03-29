using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public class QuizCollectionFakeReader : IQuizCollectionReader
    {
        public QuizCollection Read()
        {
            var coll = new QuizCollection()
            {
                new Quiz
                {
                    new TextQuestion
                    {
                        Content = "",
                        CorrectAnswers = new List<string>()
                        {
                            ""
                        }
                    },
                    new SingleOptionQuestion
                    {
                    }
                }
            };

            return coll;
        }
    }
}
