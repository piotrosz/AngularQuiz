using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AngularQuiz.Core.Model
{
    public class QuizPackage : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Quiz> Quizes { get; set; }

        [Timestamp]
        [JsonIgnore]
        public Byte[] Timestamp { get; set; }

        public int QuizCount { get { return Quizes == null ? -1 : Quizes.Count; } }
    }
}
