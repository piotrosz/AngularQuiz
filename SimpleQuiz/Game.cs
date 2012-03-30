using System;

namespace SimpleQuiz
{
    /// <summary>
    /// The quiz game. Class manages points counting and checks whether the game has finished.
    /// Has two important properties: 
    /// <see cref="AskQuestionStrategy">AskQuestionStrategy</see>
    /// <see cref="CheckAnswerStrategy">CheckAnswerStrategy</see>
    /// </summary>
    public abstract class Game
    {
        protected AskQuestionsStrategy askQuestionStrategy;
        protected CheckAnswerStrategy checkAnswerStrategy;

        public Quiz Quiz
        {
            set
            {
                this.askQuestionStrategy.Quiz = value;
                this.GameResult.MaxPoints = value.Count;
            }
        }

        /// <summary>
        /// Current game question.
        /// </summary>
        protected Question currentQuestion;

        /// <summary>
        /// The game result.
        /// </summary>
        public GameResult GameResult { get; private set; }

        public Game(AskQuestionsStrategy askQuestionStrategy, CheckAnswerStrategy checkAnswerStrategy)
        {
            this.askQuestionStrategy = askQuestionStrategy;
            this.checkAnswerStrategy = checkAnswerStrategy;

            this.GameResult = new GameResult
            {
                IsFinished = false,
                Points = 0
            };

            if (askQuestionStrategy.Quiz != null)
                this.GameResult.MaxPoints = askQuestionStrategy.Quiz.Count;
        }

        /// <summary>
        /// Gets next game question using the ask question strategy.
        /// </summary>
        /// <returns></returns>
        public Question GetNextQuestion()
        {
            currentQuestion = askQuestionStrategy.GetNextQuestion();
            return currentQuestion;
        }

        /// <summary>
        /// Checks if given answer is correct using the check answer strategy
        /// </summary>
        /// <param name="answer">The answer</param>
        /// <returns></returns>
        public CheckAnswerResult CheckAnswer(string answer)
        {
            var result = checkAnswerStrategy.Check(answer, currentQuestion);

            if (result.IsCorrect)
                GameResult.Points++;

            GameResult.IsFinished = askQuestionStrategy.IsLast;

            return result;
        }


    }

    // Asks questions randomly
    // Requires Y/N answer
    public class GameYesNo : Game
    {
        public GameYesNo()
            : base(new RandomQuestionsStrategy(), new CheckAnswerYNStrategy())
        { }

        public GameYesNo(Quiz quiz)
            : base(new RandomQuestionsStrategy(quiz), new CheckAnswerYNStrategy())
        { }
    }

    // Asks questions from the newest to the oldest
    // Requires full answer
    public class GameTest : Game
    {
        public GameTest(Quiz quiz)
            : base(new StackQuestionsStrategy(quiz), new CheckAnswerExactStrategy())
        { }

        public GameTest()
            : base(new StackQuestionsStrategy(), new CheckAnswerExactStrategy())
        { }
    }
}
