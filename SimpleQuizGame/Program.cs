using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleQuiz;

namespace SimpleQuizGame
{
    class Program
    {
        // Note: Dependency injection might be used
        private static IQuizCollectionImporter importer = new QuizCollectionDirectoryImporter() { InputDir = @"E:\prog\SimpleQuiz\samples" };
        private static Game game = new GameTest();

        static void Main()
        {
            StartQuiz();
        }

        private static void StartQuiz()
        {
            // User has to select quiz
            QuizCollection quizColl = importer.Import();

            bool quizSelected = false;
            int selectedQuizIndex = 0;

            while (!quizSelected)
            {
                UIHelper.PresentQuizCollection(quizColl);

                string input = Console.ReadLine();

                quizSelected = UIHelper.ValidateQuizNumber(input, quizColl.Count, out selectedQuizIndex);
            }

            Console.WriteLine("You've selected: {0}.", quizColl[selectedQuizIndex].Name);
            Console.WriteLine();

            // Start the game
            game.Quiz = quizColl[selectedQuizIndex];

            while (!game.GameResult.IsFinished)
            {
                // Ask next question
                UIHelper.ShowQuestion(game.GetNextQuestion());

                // Collect user answer
                string answer = Console.ReadLine();

                // Check answer and show results
                UIHelper.ShowAnswerResult(game.CheckAnswer(answer));
            }

            // Finish the game
            UIHelper.ShowGameResult(game.GameResult);

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static class UIHelper
        {
            public static bool ValidateQuizNumber(string input, int count, out int result)
            {
                int internalResult = -1;
                result = internalResult;

                if (string.IsNullOrWhiteSpace(input))
                {
                    return false;
                }

                if (!int.TryParse(input, out internalResult))
                {
                    return false;
                }

                if (internalResult < 1 || internalResult > count)
                {
                    return false;
                }

                result = internalResult - 1;
                return true;
            }

            public static void PresentQuizCollection(QuizCollection quizCollection)
            {
                Console.WriteLine("Choose quiz please:");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < quizCollection.Count(); i++)
                {
                    Console.WriteLine("{0:#0} {1}", i + 1, quizCollection[i].Name);
                }

                Console.ResetColor();
            }

            public static void ShowQuestion(Question question)
            {
                Console.WriteLine(question.Show());
            }

            public static void ShowAnswerResult(CheckAnswerResult result)
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

            public static void ShowGameResult(GameResult result)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Points: {0}", result.Points);
                Console.WriteLine("Max points: {0}", result.MaxPoints);
                Console.ResetColor();
            }
        }
    }
}
