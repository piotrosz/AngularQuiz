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

        // Methods below are virtual rather than abstract so that a developer 
        // need override only the ones that interest him.

        public virtual string Show()
        {
            if (string.IsNullOrWhiteSpace(Content))
                throw new NullReferenceException(("Question content must contain some text"));

            return Content.EndsWith("?") ? Content : string.Format("{0}?", Content);
        }

        public virtual bool IsAnswerCorrect(string answer)
        {
            if (CorrectAnswers == null || CorrectAnswers.Count() == 0)
                throw new NullReferenceException("CorrectAnswers collection cannot be null");

            if (!answer.Contains(","))
            {
                return (CorrectAnswers.Count() == 1 && CorrectAnswers.Single().ToUpper() == answer.ToUpper());
            }

            string[] answers = answer.Split(',');

            // !!! All answers have to be correct !!!

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

    // Question about word antonime
    // Single answer is required 
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
    }

    // Test question (user has to choose the correct answer(s) out of available options)
    public class OptionQuestion : Question
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
                sb.AppendFormat("{0}) {1}", item.Id, item.Name);
            }

            return sb.ToString();
        }
    }
}
