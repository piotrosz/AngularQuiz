using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Tests.Stubs
{
    internal static class StubTestQuestions
    {
        public static TestQuestion SingleAnswer 
        { 
            get 
            { 
                return new TestQuestion
                { 
                    Id = 0,
                    Content = "What is the first aphabet letter?",
                    Answers = new List<TestQuestionOption> 
                    {
                        new TestQuestionOption { Content = "A", IsCorrect = true },
                        new TestQuestionOption { Content = "B" },
                        new TestQuestionOption { Content = "C" }
                    } 
               }; 
            } 
        }

        public static TestQuestion ThreeAnswers
        {
            get
            {
                return new TestQuestion
                {
                    Id = 1,
                    Content = "Whar are three first alphabet letters?",
                    Answers = new List<TestQuestionOption>
                    {
                        new TestQuestionOption { Content = "A", IsCorrect = true },
                        new TestQuestionOption { Content = "X" },
                        new TestQuestionOption { Content = "B", IsCorrect = true },
                        new TestQuestionOption { Content = "C", IsCorrect = true },
                        new TestQuestionOption { Content = "Z" },
                        new TestQuestionOption { Content = "N" }
                    }
                };
            }
        }
    }
}
