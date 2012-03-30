using System;
using System.Collections.Generic;

namespace SimpleQuiz
{
    public class Quiz : List<Question>
    {
        public string Name { get; set; }
    }
}
