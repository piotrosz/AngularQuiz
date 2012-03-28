using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public interface IGame
    {
        GameResult GameResult { get; }
        Question GetNextQuestion();
        CheckAnswerResult CheckAnswer(string input);
    }
}
