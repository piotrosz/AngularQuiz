using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public class QuizCollectionTextParser
    {
        private const char QuestionSeparator = '?';
        private const char AnswersSeparator = ';';
        private const char CommentIndicator = '#';
        private const char OptionQuestionSeparator = '$';

        public IEnumerable<Quiz> Parse(IEnumerable<string> lines)
        {
            Quiz quiz = null;

            Queue<string> queue = new Queue<string>(lines.Where(x => !IsCommentOrEmptyLine(x)));

            while(queue.Count > 0)
            {
                string line = queue.Dequeue();

                if (IsNameLine(line))
                    quiz = new Quiz { Name = line.Trim() };

                if (IsQuestionLine(line) && quiz != null)
                {
                    string[] values = line.Split(QuestionSeparator);

                    quiz.Add(GetQuestion(values));

                    if (queue.Count == 0 || IsNameLine(queue.Peek()))
                        yield return quiz;
                }
            }
        }

        private Question GetQuestion(string[] values)
        {
            if (IsOptionQuestion(values[1]))
                return GetOptionQuestion(values);
            else
                return GetTextQuestion(values);
        }

        private OptionQuestion GetOptionQuestion(string[] values)
        {
            var question = new OptionQuestion();
            question.Content = values[0].Trim();

            string[] values2 = values[1].Split(OptionQuestionSeparator);

            var options = new List<Option>();
            var optionsCsv = GetCommaSeparated(values2[0]);

            for (int i = 0; i < optionsCsv.Count; i++)
            {
                options.Add(new Option
                {
                    Id = i.ToString(),
                    Name = optionsCsv[i]
                });
            }

            question.Options = options;
            question.CorrectAnswers = GetCommaSeparated(values2[1]);

            return question;
        }

        private TextQuestion GetTextQuestion(string[] values)
        {
            var question = new TextQuestion();
            question.Content = values[0].Trim();
            question.CorrectAnswers = GetCommaSeparated(values[1]);

            return question;
        }

        private List<string> GetCommaSeparated(string value)
        {
            return value.Split(AnswersSeparator).Select(x => x.Trim()).ToList();
        }

        private bool IsNameLine(string value)
        {
            return !value.Contains(QuestionSeparator);
        }

        private bool IsQuestionLine(string value)
        {
            return value.Contains(QuestionSeparator);
        }

        private bool IsCommentOrEmptyLine(string value)
        {
            return string.IsNullOrWhiteSpace(value) || value.Trim().StartsWith(CommentIndicator.ToString());
        }

        private bool IsOptionQuestion(string value)
        {
            return value.Contains(OptionQuestionSeparator);
        }
    }
}
