using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model.Questions
{
    public abstract class Question : Entity
    {
        [Required]
        public int QuizId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string View { get; set; }
    }
}
