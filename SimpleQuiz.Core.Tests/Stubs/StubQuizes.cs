using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;

namespace SimpleQuiz.Core.Tests.Stubs
{
    public static class StubQuizes
    {
        public static Quiz Quiz 
        { 
            get 
            {
                var quiz = new Quiz();

                quiz.OpenQuestions = new List<OpenQuestion>();
                quiz.TestQuestions = new List<TestQuestion>();
                quiz.CategoryQuestions = new List<CategoryQuestion>();
                quiz.SortQuestions = new List<SortQuestion>();

                quiz.OpenQuestions.Add(StubOpenQuestions.SingleAnswerSingleOptionQuestion);
                quiz.OpenQuestions.Add(StubOpenQuestions.SingleAnswerThreeOptionsQuestion);
                quiz.OpenQuestions.Add(StubOpenQuestions.ThreeAnswersSingleOptionQuestion);
                quiz.OpenQuestions.Add(StubOpenQuestions.ThreeAnswersThreeOptionsQuestion);
                quiz.TestQuestions.Add(StubTestQuestions.SingleAnswer);
                quiz.TestQuestions.Add(StubTestQuestions.ThreeAnswers);
                quiz.SortQuestions.Add(StubSortQuestions.SortQuestion);
                quiz.CategoryQuestions.Add(StubCategoryQuestions.CategoryQuestion);

                return quiz;
            } 
        }
    }
}
