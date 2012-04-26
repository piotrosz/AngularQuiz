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
        
        static void Main()
        {
            var quizColl = importer.Import();

            const char quit = 'q';
            char input;
            do
            {
                StartQuiz(quizColl);

                Console.WriteLine();
                Console.WriteLine("Press '{0}' to quit. Press enter to start next quiz.", quit);
                input = Console.ReadKey().KeyChar;
            }
            while (input != quit);
        }

        static void StartQuiz(IEnumerable<Quiz> quizColl)
        {
            Game game = new GameTest();

            // User has to select quiz first
            bool quizSelected = false;
            int selectedQuizIndex = 0;

            while (!quizSelected)
            {
                UIHelper.PresentQuizCollection(quizColl);

                string input = Console.ReadLine();

                quizSelected = UIHelper.ValidateQuizNumber(input, quizColl.Count(), out selectedQuizIndex);
            }

            Quiz quiz = quizColl.ElementAt(selectedQuizIndex);

            Console.Write("You've selected: ");
            UIHelper.WriteLineColor(ConsoleColor.White, quiz.Name);

            // Start the game
            game.Quiz = quiz;

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

            public static void PresentQuizCollection(IEnumerable<Quiz> quizCollection)
            {
                Console.WriteLine("Choose quiz please:");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

                int i = 1;
                foreach (Quiz quiz in quizCollection)
                {
                    Console.WriteLine("{0:#0} {1}", i, quiz.Name);
                    i++;
                }

                Console.ResetColor();
            }

            public static void ShowQuestion(Question question)
            {
                Console.WriteLine(question.Show());
            }

            public static void ShowAnswerResult(CheckAnswerResult result)
            {
                ConsoleColor color = result.IsCorrect ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;

                WriteLineColor(color, result.CorrectAnswersLine);
                Console.WriteLine();
            }

            public static void ShowGameResult(GameResult result)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Points: {0}", result.Points);
                Console.WriteLine("Max points: {0}", result.MaxPoints);
                Console.ResetColor();
            }

            public static void WriteLineColor(ConsoleColor color, string format, params object[] arg)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(format, arg);
                Console.ResetColor();
            }
        }
    }
}
