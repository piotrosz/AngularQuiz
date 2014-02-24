using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model
{
    public class QuestionCorrectAnswerOption : Entity
    {
        public QuestionCorrectAnswerOption() {}

        public QuestionCorrectAnswerOption(string content)
        {
            Content = content;
        }

        public int QuestionCorrectAnswerId { get; set; }

        public virtual QuestionCorrectAnswer QuestionCorrectAnswer { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
