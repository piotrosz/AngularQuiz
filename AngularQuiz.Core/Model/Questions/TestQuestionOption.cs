using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AngularQuiz.Core.Model.Questions
{
    public class TestQuestionOption : Entity
    {
        [Required]
        [StringLength(1024)]
        public string Content { get; set; }

        public int TestQuestionId { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}
