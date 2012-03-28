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

        public QuizCollection Read()
        {
            string[] files = Directory.GetFiles(InputDir, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);

                Quiz quiz = new Quiz();

                foreach (string line in lines)
                {
                    if (line.StartsWith("#"))
                    {
                        if (quiz.Count > 0)
                            quizCollection.Add(quiz);

                        quiz = new Quiz();
                        quiz.Name = line.Replace("#", "").Trim();
                    }
                    else
                    {
                        string[] values = line.Split(';');

                        var question = new WordQuestion();
                        question.Content = values[0].Trim();
                        question.CorrectAnswers = values[1].Split(',');

                        quiz.Add(question);
                    }
                }

                quizCollection.Add(quiz);
            }

            return quizCollection;
        }
    }
}
