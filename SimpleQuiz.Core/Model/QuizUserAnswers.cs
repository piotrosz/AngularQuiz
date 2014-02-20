using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model
{
    public class QuizUserAnswers
    {
        public QuizUserAnswers(int quizId)
        {
            QuizId = quizId;
        }

        public int QuizId { get; private set; }
        public List<QuestionUserAnswer> Answers { get; set; }
    }
}
