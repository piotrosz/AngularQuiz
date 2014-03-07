using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model.Questions
{
    public class QuestionUserAnswer
    {
        public QuestionUserAnswer(int questionId)
        {
            QuestionId = questionId;
            Answers = new List<string>();
        }

        public QuestionUserAnswer(int questionId, string singleAnswer)
        {
            QuestionId = questionId;
            Answers = new List<string> { singleAnswer };
        }

        public int QuestionId { get; private set; }

        public List<string> Answers { get; set; }
    }
}
