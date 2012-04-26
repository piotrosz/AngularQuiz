using System;
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

        private IEnumerable<string> ReadAllLines()
        {
            string[] files = Directory.GetFiles(InputDir, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                foreach (string line in File.ReadLines(file))
                {
                    yield return line;
                }
            }
        }

        public IEnumerable<Quiz> Import()
        {
            return new QuizCollectionTextParser()
                .Parse(ReadAllLines());
        }
    }
}
