using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.AnswerCheck
{
    // Full correct answer text is required.
    // Ignores case, uses current culture.
    // Answers order is significant.
    public class CheckAnswerOpenQuestionStrategy : ICheckAnswerStrategy<OpenQuestion>
    {
        public CheckAnswerResult Check(QuestionUserAnswer userAnswer, OpenQuestion question)
        {
            if(question == null)
            {
                throw new ArgumentNullException("question");
            }

            if(userAnswer == null)
            {
                throw new ArgumentNullException("userAnswer");
            }

            if(userAnswer.Answers == null)
            {
                throw new ArgumentNullException("userAnswer.Answers");
            }

            if(question.Answers == null)
            {
                throw new ArgumentNullException("question.Answers");
            }

            if(userAnswer.Answers.Count != question.Answers.Count())
            {
                throw new ArgumentException("Number of user answers must be the same as the number of question answers", "userAnswer");
            }

            var result = new CheckAnswerResult(question) { IsCorrect = true };

            for (int answerIndex = 0; answerIndex < userAnswer.Answers.Count; answerIndex++)
            {
                OpenQuestionCorrectAnswer correctAnswer = question.Answers.OrderBy(a => a.OrderId).ElementAt(answerIndex);

                if (correctAnswer.CorrectAnswerOptions.Any(
                    o => o.Content.Equals(userAnswer.Answers[answerIndex], StringComparison.CurrentCultureIgnoreCase))
                    )
                {
                    result.CorrectAswersIds.Add(correctAnswer.Id);
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
