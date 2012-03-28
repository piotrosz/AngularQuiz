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

    public class WordQuestion : Question
    {
        public override string Show()
        {
            return string.Format("{0}?", Content);
        }

        public override bool IsAnswerCorrect(string answer)
        {
            return CorrectAnswers.Any(x => x.ToUpper() == answer.ToUpper());
        }
    }

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
