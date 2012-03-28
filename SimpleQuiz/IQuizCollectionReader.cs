using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public interface IQuizCollectionReader
    {
        QuizCollection Read();
    }
}
