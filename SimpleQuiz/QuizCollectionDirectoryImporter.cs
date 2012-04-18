﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleQuiz
{
    /// <summary>
    /// Imports all quizes from a given directory.
    /// </summary>
    public class QuizCollectionDirectoryImporter : IQuizCollectionImporter
    {
        public string InputDir { get; set; }

        private QuizCollection quizCollection = new QuizCollection();

        // TODO: Add file contents validation
        public QuizCollection Import()
        {
            string[] files = Directory.GetFiles(InputDir, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);

                var quiz = new Quiz();

                foreach (string line in lines.Where(x => !IsCommentOrEmptyLine(x)))
                {
                    if (IsNameLine(line))
                    {
                        if (quiz.Count > 0)
                            quizCollection.Add(quiz);

                        quiz = new Quiz { Name = line.Trim() };
                    }

                    if (IsQuestionLine(line))
                    {
                        string[] values = line.Split('?');

                        if (IsOptionQuestion(values[1]))
                        {
                            quiz.Add(GetOptionQuestion(values));
                        }
                        else
                        {
                            quiz.Add(GetTextQuestion(values));
                        }
                    }
                }

                quizCollection.Add(quiz);
            }

            return quizCollection;
        }

        private OptionQuestion GetOptionQuestion(string[] values)
        {
            var question = new OptionQuestion();
            question.Content = values[0].Trim();

            string[] values2 = values[1].Split('$');

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
            return value.Split(';').Select(x => x.Trim()).ToList();
        }

        private bool IsNameLine(string value)
        {
            return !value.Contains("?");
        }

        private bool IsQuestionLine(string value)
        {
            return value.Contains("?");
        }

        private bool IsCommentOrEmptyLine(string value)
        {
            return string.IsNullOrWhiteSpace(value) || value.Trim().StartsWith("#");
        }

        private bool IsOptionQuestion(string value)
        {
            return value.Contains("$");
        }
    }
}
