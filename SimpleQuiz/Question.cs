using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SimpleQuiz
{
    [DebuggerDisplay("{Content}")]
    public abstract class Question
    {
        public string Content { get; set; }
        public IEnumerable<string> CorrectAnswers { get; set; }

        public abstract string Show();

        public abstract bool IsAnswerCorrect(string answer);
    }

    // Question about word antonime
    public class AntomineQuestion : Question
    {
        public override string Show()
        {
            return string.Format("What is the antonime for: {0}?", Content);
        }

        public override bool IsAnswerCorrect(string answer)
        {
            return CorrectAnswers.Any(x => x.ToUpper() == answer.ToUpper());
        }
    }

    // Question with text answer required
    public class TextQuestion : Question
    {
        public override string Show()
        {
            return string.Format("{0}?", Content);
        }

        public override bool IsAnswerCorrect(string answer)
        {
            if (CorrectAnswers == null || CorrectAnswers.Count() == 0)
                throw new NullReferenceException("CorrectAnswers collection cannot be null");

            if (!answer.Contains(","))
            {
                return (CorrectAnswers.Count() == 1 && CorrectAnswers.Single().ToUpper() == answer);
            }

            string[] answers = answer.Split(',');

            if (answers == null || answers.Length == 0)
            {
                return false;
            }
            else
            {
                foreach (var item in this.CorrectAnswers)
                {
                    if (!answers.Any(x => x.ToUpper() == item.ToUpper()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    // Option/test question with single correct answer
    public class SingleOptionQuestion : Question
    {
        public IEnumerable<Option> Options { get; set; }

        public override string Show()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Content + "?");
            sb.AppendLine("Choose the correct answer.");
            foreach (var item in Options)
            {
                sb.AppendLine();
                sb.AppendFormat("{0}. {1}", item.Id, item.Name);
            }

            return sb.ToString();
        }

        public override bool IsAnswerCorrect(string answer)
        {
            return CorrectAnswers.Any(x => x.ToUpper() == answer.ToUpper());
        }
    }
}
