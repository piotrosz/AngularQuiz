using Newtonsoft.Json;
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
        [StringLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Quiz> Quizes { get; set; }

        [Timestamp]
        [JsonIgnore]
        public Byte[] Timestamp { get; set; }
    }
}
