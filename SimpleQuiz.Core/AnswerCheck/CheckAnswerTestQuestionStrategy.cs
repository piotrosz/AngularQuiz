using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class CheckAnswerTestQuestionStrategy : ICheckAnswerStrategy<TestQuestion>
    {
        public CheckAnswerResult Check(QuestionUserAnswer userAnswer, TestQuestion question)
        {
            var result = new CheckAnswerResult(question);
            result.IsCorrect = true;

            foreach (var answer in userAnswer.Answers)
            {
                var option = question.Answers
                    .Where(o => o.IsCorrect)
                    .FirstOrDefault(o => o.Content.Equals(answer, StringComparison.CurrentCultureIgnoreCase));       

                if(option == null)
                {
                    result.IsCorrect = false;
                }
                else
                {
                    result.CorrectAswersIds.Add(option.Id);
                }
            }

            return result;
        }
    }
}
