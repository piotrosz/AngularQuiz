using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.Tests.Stubs
{
    internal static class StubCategoryQuestions
    {
        public static CategoryQuestion CategoryQuestion
        {
            get
            {
                return new CategoryQuestion
                {
                    Content = "Assign to categories",
                    Options = new List<CategoryQuestionOption>
                    {
                        new CategoryQuestionOption { Content = "A", Category = "Alphabet", OrderId = 1 },
                        new CategoryQuestionOption { Content = "B", Category = "Alphabet", OrderId = 2 },
                        new CategoryQuestionOption { Content = "1", Category = "Number", OrderId = 3 },
                        new CategoryQuestionOption { Content = "goose", Category = "Bird", OrderId = 4 },
                        new CategoryQuestionOption { Content = "hen", Category = "Bird", OrderId = 5 }
                    }
                };
            }
        }
    }
}
