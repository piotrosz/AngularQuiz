using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleQuiz;

namespace SimpleQuizGame
{
    class Program
    {
        static void Main()
        {
            // Note: Dependency injection might be used
            IQuizCollectionReader reader = new QuizCollectionDirectoryReader() { InputDir = "E:\\" };


            // User has to select quiz
            QuizCollection quizColl = reader.Read();

            bool quizSelected = false;
            int selectedQuizIndex = 0;

            while (!quizSelected)
            {
                PresentQuizCollection(quizColl);

                string input = Console.ReadLine();

                quizSelected = ValidateQuizNumber(input, quizColl.Count, out selectedQuizIndex);
            }

            Console.WriteLine("You've selected: {0}.", quizColl[selectedQuizIndex].Name);
            Console.WriteLine();


            // Quiz has been selected - start the game
            Quiz selectedQuiz = quizColl[selectedQuizIndex];
            Game game = new GameYesNo(selectedQuiz);

            while (!game.GameResult.IsFinished)
            {
                ShowQuestion(game.GetNextQuestion());

                string input = Console.ReadLine();

                ShowAnswerResult(game.CheckAnswer(input));
            }

            ShowGameResult(game.GameResult);

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static bool ValidateQuizNumber(string input, int count, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                result = 0;
                return false;
            }

            if (!int.TryParse(input, out result))
            {
                return false;
            }

            if (result < 0 || result >= count)
            {
                return false;
            }

            return true;
        }

        private static void PresentQuizCollection(QuizCollection quizCollection)
        {
            Console.WriteLine("Choose quiz please:");

            for (int i = 0; i < quizCollection.Count(); i++)
            {
                Console.WriteLine("{0:#0} {1}", i, quizCollection[i].Name);
            }
        }

        private static void ShowQuestion(Question question)
        {
            Console.WriteLine(question.Show());
        }

        private static void ShowAnswerResult(CheckAnswerResult result)
        {
            if (result.IsCorrect)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(result.CorrectAnswersLine);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(result.CorrectAnswersLine);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private static void ShowGameResult(GameResult result)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Points: {0}", result.Points);
            Console.WriteLine("Max points: {0}", result.MaxPoints);
            Console.ResetColor();

        }
    }
}
