using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz.CheckAnswerStrategy
{
    //Full correct answer text is required
    //ignores case, uses current culture
    public class AnswerExactStrategy : ICheckAnswerStrategy
    {
        public CheckAnswerResult Check(QuestionUserAnswer userAnswer, Question question)
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

            if(userAnswer.Answers.Count != question.CorrectAnswers.Count())
            {
                throw new ArgumentException("Number of user answers must be the same as the number of question answers", "userAnswer");
            }

            var result = new CheckAnswerResult(question);

            result.IsCorrect = true;

            for (int answerIndex = 0; answerIndex < userAnswer.Answers.Count; answerIndex++)
            {
                QuestionCorrectAnswer correctAnswer = question.CorrectAnswers.OrderBy(a => a.OrderId).ElementAt(answerIndex);

                if (correctAnswer.CorrectAnswerOptions.Any(
                    o => o.Content.Equals(userAnswer.Answers[answerIndex], StringComparison.CurrentCultureIgnoreCase))
                    )
                {
                    result.CorrectAswersIds.Add(correctAnswer.Id);
                }
                else
                {
                    result.IsCorrect = false;
                    result.IncorrectAnswersIds.Add(correctAnswer.Id);
                }
            }

            return result;
        }
    }
}
