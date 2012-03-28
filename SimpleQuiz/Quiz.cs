using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleQuiz
{
    public class Quiz : List<Question>
    {
        public string Name { get; set; }
    }
}
