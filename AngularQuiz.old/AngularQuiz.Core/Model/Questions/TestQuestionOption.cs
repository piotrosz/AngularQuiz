using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AngularQuiz.Core.Model;

namespace AngularQuiz.Core.Model.Questions
{
    public class TestQuestionOption : Entity
    {
        [Required]
        [StringLength(1024)]
        public string Content { get; set; }

        public int TestQuestionId { get; set; }

        [Secret]
        public bool IsCorrect { get; set; }
    }
}
