using SimpleQuiz.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleQuiz.Core.Model
{
    public class Quiz : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }

        public int QuizPackageId { get; set; }

        public virtual QuizPackage QuizPackage { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
