using System;
using System.Collections.Generic;

namespace SimpleQuiz
{
    public interface IQuizCollectionImporter
    {
        IEnumerable<Quiz> Import();
    }
}
