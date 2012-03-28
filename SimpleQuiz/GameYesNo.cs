using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    /// <summary>
    /// Does not require axact answer.
    /// User declares they know the answer.
    /// </summary>
    public class GameYesNo : IGame
    {
        private Quiz quiz;

        public GameYesNo(Quiz quiz)
        {
            this.quiz = quiz;
            this.GameResult = new GameResult
            {
                IsFinished = false,
                MaxPoints = quiz.Count,
                Points = 0
            };

            foreach (var question in quiz)
	        {
                queue.Enqueue(question);
	        }
            
        }

        public GameResult GameResult { get; private set; }

        private Queue<Question> queue = new Queue<Question>();
        private Question currentQuestion;

        public Question GetNextQuestion()
        {
            currentQuestion = queue.Dequeue();
            return currentQuestion;
        }

        public CheckAnswerResult CheckAnswer(string input)
        {
            if (queue.Count == 0)
                GameResult.IsFinished = true;

            var result = new CheckAnswerResult { CorrectAnswers = currentQuestion.CorrectAnswers };

            if (input.ToUpper() == "Y")
            {
                GameResult.Points++;
                result.IsCorrect = true;
            }
            else
            {
                result.IsCorrect = false;
            }

            return result;
        }
    }
}
