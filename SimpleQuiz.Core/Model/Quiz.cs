using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleQuiz.Core.Model
{
    public class Quiz : Entity
    {
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
