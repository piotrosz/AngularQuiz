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
                        new CategoryQuestionOption { Content = }
                    }
                }
            }
        }
    }
}
