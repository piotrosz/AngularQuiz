using Newtonsoft.Json;
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

        public virtual ICollection<Question> Questions { get; set; }

        public int QuizPackageId { get; set; }

        [JsonIgnore]
        public virtual QuizPackage QuizPackage { get; set; }

        [JsonIgnore]
        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
