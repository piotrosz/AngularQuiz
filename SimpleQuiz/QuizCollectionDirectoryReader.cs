using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleQuiz
{
    public class QuizCollectionDirectoryReader : IQuizCollectionReader
    {
        public string InputDir { get; set; }

        private QuizCollection quizCollection = new QuizCollection();

        // TODO: Add file contents validation
        public QuizCollection Read()
        {
            string[] files = Directory.GetFiles(InputDir, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);

                Quiz quiz = new Quiz();

                foreach (string line in lines)
                {
                    if (line.StartsWith("#")) // Name line
                    {
                        if (quiz.Count > 0)
                            quizCollection.Add(quiz);

                        quiz = new Quiz();
                        quiz.Name = line.Substring(1).Trim();
                    }
                    else
                    {
                        string[] values = line.Split(';');

                        if (values[1].Contains("$"))
                        {
                            quiz.Add(GetSingleOptionQuestion(values));
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

        private SingleOptionQuestion GetSingleOptionQuestion(string[] values)
        {
            var question = new SingleOptionQuestion();
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
            return value.Split(',').Select(x => x.Trim()).ToList();
        }
    }
}
