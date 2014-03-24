using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model.Questions
{
    public class QuizUserAnswers
    {
        public QuizUserAnswers()
        {
            OpenQuestionsAnswers = new List<QuestionUserAnswer>();
            TestQuestionsAnswers = new List<QuestionUserAnswer>();
            SortQuestionsAnswers = new List<QuestionUserAnswer>();
            CategoryQuestionsAnswers = new List<QuestionUserAnswer>();
        }

        public List<QuestionUserAnswer> OpenQuestionsAnswers { get; set; }
        public List<QuestionUserAnswer> TestQuestionsAnswers { get; set; }
        public List<QuestionUserAnswer> SortQuestionsAnswers { get; set; }
        public List<QuestionUserAnswer> CategoryQuestionsAnswers { get; set; }

        public int TotalAnswersCount 
        {
            get 
            { 
                return 
                OpenQuestionsAnswers.Count + 
                TestQuestionsAnswers.Count + 
                SortQuestionsAnswers.Count + 
                CategoryQuestionsAnswers.Count; 
            }
        }
    }
}
