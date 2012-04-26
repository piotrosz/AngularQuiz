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

            var queue = new Queue<string>(lines.Where(x => !Is.CommentOrEmpty(x)));

            while (queue.Count > 0)
            {
                string line = queue.Dequeue();

                if (Is.Name(line))
                    quiz = new Quiz { Name = line.Trim() };

                if (Is.Question(line) && quiz != null)
                {
                    string[] values = line.Split(QuestionSeparator);

                    quiz.Add(Get.Question(values));

                    if (queue.Count == 0 || Is.Name(queue.Peek()))
                        yield return quiz;
                }
            }
        }

        class Is
        {
            public static bool Name(string line)
            {
                return !line.Contains(QuestionSeparator);
            }

            public static bool Question(string line)
            {
                return line.Contains(QuestionSeparator);
            }

            public static bool CommentOrEmpty(string line)
            {
                return string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith(CommentIndicator.ToString());
            }

            public static bool OptionQuestion(string line)
            {
                return line.Contains(OptionQuestionSeparator);
            }
        }

        class Get
        {
            public static Question Question(string[] values)
            {
                if (Is.OptionQuestion(values[1]))
                    return OptionQuestion(values);
                else
                    return TextQuestion(values);
            }

            public static OptionQuestion OptionQuestion(string[] values)
            {
                var question = new OptionQuestion();
                question.Content = values[0].Trim();

                string[] values2 = values[1].Split(OptionQuestionSeparator);

                var options = new List<Option>();
                var optionsCsv = CommaSeparated(values2[0]);

                for (int i = 0; i < optionsCsv.Count; i++)
                {
                    options.Add(new Option
                    {
                        Id = i.ToString(),
                        Name = optionsCsv[i]
                    });
                }

                question.Options = options;
                question.CorrectAnswers = CommaSeparated(values2[1]);

                return question;
            }

            public static TextQuestion TextQuestion(string[] values)
            {
                var question = new TextQuestion();
                question.Content = values[0].Trim();
                question.CorrectAnswers = CommaSeparated(values[1]);

                return question;
            }

            public static List<string> CommaSeparated(string value)
            {
                return value.Split(AnswersSeparator).Select(x => x.Trim()).ToList();
            }
        }
    }
}
