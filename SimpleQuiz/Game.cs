using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public abstract class Game
    {
        protected AskQuestionsStrategy questionStrategy;
        protected CheckAnswerStrategy checkAnswerStrategy;

        protected Question currentQuestion;

        public GameResult GameResult { get; private set; }

        public Game(AskQuestionsStrategy questionStrategy, CheckAnswerStrategy checkAnswerStrategy)
        {
            this.questionStrategy = questionStrategy;
            this.checkAnswerStrategy = checkAnswerStrategy;

            this.GameResult = new GameResult
            {
                IsFinished = false,
                MaxPoints = questionStrategy.Quiz.Count,
                Points = 0
            };
        }

        public Question GetNextQuestion()
        {
            currentQuestion = questionStrategy.GetNextQuestion();
            return currentQuestion;
        }

        public CheckAnswerResult CheckAnswer(string input)
        {
            var result = checkAnswerStrategy.Check(input, currentQuestion);

            if (result.IsCorrect)
                GameResult.Points++;

            GameResult.IsFinished = questionStrategy.IsLast;

            return result;
        }
    }

    // Asks questions randomly
    // Requires Y/N answer
    public class GameYesNo : Game
    {
        public GameYesNo(Quiz quiz)
            : base(new RandomQuestionsStrategy(quiz), new CheckAnswerYNStrategy())
        { }
    }


    public class GameTest : Game
    {
        public GameTest(Quiz quiz)
            : base(new StackQuestionsStrategy(quiz), new CheckAnswerExactStrategy())
        { }
    }
}
