using Newtonsoft.Json;
using AngularQuiz.Core.Model;
using AngularQuiz.Core.Model.Questions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularQuiz.Core.Model
{
    public class Quiz : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string View { get; set; }

        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
        
        public virtual ICollection<SortQuestion> SortQuestions { get; set; }

        public virtual ICollection<OpenQuestion> OpenQuestions { get; set; }

        public virtual ICollection<CategoryQuestion> CategoryQuestions { get; set; }

        public int QuizPackageId { get; set; }

        [JsonIgnore]
        public virtual QuizPackage QuizPackage { get; set; }
    }
}
