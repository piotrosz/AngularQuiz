using SimpleQuiz.Core.Model;
using System;
using System.Linq;

namespace SimpleQuiz.CheckAnswerStrategy
{
    // Only declaration that the answer is known is required
    public class CheckAnswerYNStrategy : ICheckAnswerStrategy
    {
        private string _yesWord;

        public CheckAnswerYNStrategy(string yesWord)
        {
            _yesWord = yesWord;
        }

        public CheckAnswerResult Check(QuestionUserAnswer userAnswer, Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException("question");
            }

            if (userAnswer == null)
            {
                throw new ArgumentNullException("userAnswer");
            }

            if (userAnswer.Answers == null)
            {
                throw new ArgumentNullException("userAnswer.Answers");
            }

            if(userAnswer.Answers.Count != 1)
            {
                throw new ArgumentException("Number of user answers must be 1");
            }

            var result = new CheckAnswerResult(question);
            result.IsCorrect = userAnswer.Answers.First().Equals(_yesWord, StringComparison.InvariantCultureIgnoreCase);

            return result;
        }
    }
}
