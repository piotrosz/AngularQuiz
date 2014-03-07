using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleQuiz.Core.Model.Questions
{
    public class OpenQuestionCorrectAnswerOption : Entity
    {
        public OpenQuestionCorrectAnswerOption() {}

        public OpenQuestionCorrectAnswerOption(string content)
        {
            Content = content;
        }

        public int OpenQuestionCorrectAnswerId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Content { get; set; }
    }
}
