using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model
{
    public class QuizPackage : Entity
    {
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Quiz> Quizes { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
