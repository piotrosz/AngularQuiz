using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz.Core.AnswerCheck
{
    public class CheckAnswerCategoryQuestionStrategy : ICheckAnswerStrategy<CategoryQuestion>
    {
        public CheckAnswerResult Check(QuestionUserAnswer userAnswer, CategoryQuestion question)
        {
            if(userAnswer == null)
            {
                throw new ArgumentNullException("userAnswer");
            }

            if(question == null)
            {
                throw new ArgumentNullException("question");
            }

            if(question.Options == null)
            {
                throw new ArgumentNullException("question.Options");
            }

            if(userAnswer.Answers == null)
            {
                throw new ArgumentNullException("userAnswer.Answers");
            }

            if(question.Options.Count != userAnswer.Answers.Count)
            {
                throw new ArgumentException("Number of user answers must be the same as the number of question options");
            }

            var result = new CheckAnswerResult(question) { IsCorrect = true };
            var orderedOptions = question.Options.OrderBy(o => o.OrderId);

            for (int i = 0; i < userAnswer.Answers.Count; i++)
            {
                var option = orderedOptions.ElementAt(i);

                if(option.Category == userAnswer.Answers[i])
                {
                    result.CorrectAswersIds.Add(option.Id);
                }
                else
                {
                    result.IsCorrect = false;
                }
            }

            return result;
        }
    }
}
