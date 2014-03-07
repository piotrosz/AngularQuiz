using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleQuiz.Core.Model;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class CheckQuizAnswersResult
    {
        public CheckQuizAnswersResult(Quiz quiz)
        {
            Quiz = quiz;
            AnswersResults = new List<CheckAnswerResult>();
        }

        public Quiz Quiz { get; private set; }
        public List<CheckAnswerResult> AnswersResults { get; set; }
    }
}
