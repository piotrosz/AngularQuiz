using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public abstract class CheckAnswerStrategy
    {
        public abstract CheckAnswerResult Check(string input, Question question);
    }

	// Only declaration that the answer is known is required
    public class CheckAnswerYNStrategy : CheckAnswerStrategy
    {
        public override CheckAnswerResult Check(string input, Question question)
        {
            var result = new CheckAnswerResult();
            result.CorrectAnswers = question.CorrectAnswers;
            result.IsCorrect = input.ToUpper() == "Y";
            
            return result;
        }
    }

	// Full correct answer text is required
    public class CheckAnswerExactStrategy : CheckAnswerStrategy
    {
        public override CheckAnswerResult Check(string input, Question question)
        {
            var result = new CheckAnswerResult();
            result.CorrectAnswers = question.CorrectAnswers;
            result.IsCorrect = question.IsAnswerCorrect(input);

            return result;
        }
    }

}
